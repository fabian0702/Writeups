## [HV23.04] Bowser (veganjay)
### Description
> Santa has heard that some kids appreciate a video game as a christmas gift. He would rather have the kids solve some CTF challenges, so he took some inspiration and turned it into a challenge. Can you save the princess?   

### Solution
After opening the provided binary in ghidra we get the following main function:  
```c
int main(int argc, char **argv) {

  char flag[75] = {0xac,  0x90,  0x8d,  0x8d,  0x86,  0xd3,  0xdf,  0x86,  0x90,  0x8a,  0x8d,  0xdf,  0x99,  0x93,  0x9e,  0x98,  0xdf,  0x96,  0x8c,  0xdf,  0x96,  0x91,  0xdf,  0x9e,  0x91,  0x90,  0x8b,  0x97,  0x9a,  0x8d,  0xdf,  0x9c,  0x9e,  0x8c,  0x8b,  0x93,  0x9a,  0xd1,  0xff,  0xb7,  0xa9,  0xcd,  0xcf,  0xcd,  0xcc,  0x84,  0xa6,  0x90,  0x8a,  0xa0,  0xb7,  0x9e,  0x89,  0x9a,  0xa0,  0xac,  0x9e,  0x89,  0x9a,  0x9b,  0xa0,  0x8b,  0x97,  0x9a,  0xa0,  0xaf,  0x8d,  0x96,  0x91,  0x9c,  0x9a,  0x8c,  0x8c,  0x82,  0x0};

  if (argc == 2) {
    if (strcmp(argv[1],"mario") == 0) {
      for (char* c = flag; *c != NULL; c++)
        *c = ~*c;
      puts(flag);
      return 0;
    }
    else {
      puts("Sorry, that is not the correct password.");
      return 1;
    }
  }
  else {
    printf("Usage: %s password\n",*argv);
    return 1;
  }
}
```
Firstly the flag array is initialized with 75 hex values. Then the password is checked, in this case the password is "mario". After this the flag is decoded and printed. Seems simple enough. But if you run the binary with the correct password, you just get "Sorry, your flag is in another castle.". But if you look closly, the output is way less that 75 characters. Thats because after "." there is a null byte and puts stops at null bytes. If you instead open the binary in gdb and use ```print flag``` while being at a breakpoint just before puts you get the flag.
```python
from pwn import *

p = gdb.debug(['bowser.elf', 'mario'], exe='bowser.elf', api=True, gdbscript='''
break *main+319
continue &''')
p.gdb.execute('print flag')
```
Flag: **HV23{You_Have_Saved_the_Princess}**
