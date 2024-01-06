## [HV23.22] Secure Gift Wrapping Service (darkice)
### Description
> This year, a new service has been launched to support the elves in wrapping gifts. Due to a number of stolen gifts in recent days, increased security measures have been introduced and the gifts are being stored in a secret place. As Christmas is getting closer, the elves need to load the gifts onto the sleigh, but they can’t find them. The only hint to this secret place was probably also packed in one of these gifts. Can you take a look at the service and see if you can find the secret?
### Solution
In the handout there is a libc, the challenge binary, Dockerfile and example flag file. I then loaded the challenge binary into ghidra and got after some disassembly this:
```c
void main(){
  char recipient [264];

  setvbuf(stdin, 0x0, 2, 0);
  setvbuf(stdout, 0x0, 2, 0);

  puts("Welcome to the secure gift wrapping service!\n");
  printf("Who should the gifts be for? ");
  fgets(recipient, 20, stdin);
  printf("Processing the wishes of ");
  printf(recipient);

  for (int i = 0; i < 5; i++) {
    printf("\nName a wish: ");
    fgets(recipient, 512, stdin);
    strncpy(&gifts + i * 32),recipient,0x100);
    puts("Succesfully wrapped the gift!");
  }
  puts("\nAll gifts were wrapped and will be stored securely in a secret place ...");

  seccomp = seccomp_init(0);
  seccomp_rule_add(ctx,0x7fff0000,0x3c,0);
  seccomp_rule_add(ctx,0x7fff0000,0xe7,0);
  seccomp_rule_add(ctx,0x7fff0000,0,0);
  seccomp_rule_add(ctx,0x7fff0000,2,0);
  seccomp_rule_add(ctx,0x7fff0000,0x101,0);
  seccomp_rule_add(ctx,0x7fff0000,9,0);
  seccomp_rule_add(ctx,0x7fff0000,3,0);
  seccomp_load(ctx);
  seccomp_release(ctx);

  FILE *secret = open("secret.txt", O_RDONLY);
  read(secret, &gifts, 0x100);
  close(secret);

  long secret = rand();
  void* secretLocation = mmap(secret * 4096, 4096, PROT_READ | PROT_WIRTE, MAP_PRIVATE | MAP_ANONYMOUS, 0, 0);
  *secretLocation = gifts;
  secretLocation[191] = 0;
  void *rest = secretLocation % 8;
  void *current = &gifts - rest;
  secretLocation = (secretLocation + 1) & 0xfffffffffffffff8;

  for (int j = rest + 192; j != 0; j--) {
    *secretLocation = *current;
    current++;
    secretLocation++;
  }

  memset(&gifts,0,0x600);
}
```
The above code basically does the following:
- It reads a input from the user and then prints it with printf -> formatstring vulnerability
- It ready 5 times a string from the user into recipient which then gets copied into the gifts struct -> bufferoverflow
- It initializes and configures a seccomp filter which restricts the available syscalls
- It reads the flag and writes it into the gifts struct
- It copies gifts to a "secret" location
Given the above mentioned vulnerabilities, this would normally be a quite straight forward challenge, but the seccomp filter complicates things. The seccomp rules can be dumped with [seccomp-tools](https://github.com/david942j/seccomp-tools):

```
 line  CODE  JT   JF      K
=================================
 0000: 0x20 0x00 0x00 0x00000004  A = arch
 0001: 0x15 0x00 0x0b 0xc000003e  if (A != ARCH_X86_64) goto 0013
 0002: 0x20 0x00 0x00 0x00000000  A = sys_number
 0003: 0x35 0x00 0x01 0x40000000  if (A < 0x40000000) goto 0005
 0004: 0x15 0x00 0x08 0xffffffff  if (A != 0xffffffff) goto 0013
 0005: 0x15 0x06 0x00 0x00000000  if (A == read) goto 0012
 0006: 0x15 0x05 0x00 0x00000002  if (A == open) goto 0012
 0007: 0x15 0x04 0x00 0x00000003  if (A == close) goto 0012
 0008: 0x15 0x03 0x00 0x00000009  if (A == mmap) goto 0012
 0009: 0x15 0x02 0x00 0x0000003c  if (A == exit) goto 0012
 0010: 0x15 0x01 0x00 0x000000e7  if (A == exit_group) goto 0012
 0011: 0x15 0x00 0x01 0x00000101  if (A != openat) goto 0013
 0012: 0x06 0x00 0x00 0x7fff0000  return ALLOW
 0013: 0x06 0x00 0x00 0x00000000  return KILL
```
Due to the seccomp filter, you can only use open, mmap, close, read. On first glance those syscalls seem useless, as the flag is already in memory to be more exact in the "secret" locations. But this "secret" location which is initalized with a random address is actually allways at the same location because the prng isn't seeded. But just writing the flag to stdout isnt possible due to the seccomp filter. Insted it is actually possible to perform a timing attack with read, because if you call read, the process will wait for input. With this primitive we can extract 1 bit of the flag at a time.   
I then used strncpy to copy one character of the flag into a register which i then anded with a value which resulted in either 0 or the value. Based on this I then either crashed or called read. The final ropchain in c looks like:
```c
char c;
strncpy(flag + characterNumber, c, 1);
c = c & (1 << bit);
if (c != 0) {
    read(0, gifts, 1);
} else {
    // crash
}
```

The complete solve.py can be found [here](solve.py)

Flag: **HV23{t1m3_b4s3d_s3cr3t_exf1ltr4t10n}**