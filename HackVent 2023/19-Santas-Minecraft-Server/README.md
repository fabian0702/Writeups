## [HV23.19] Santa's Minecraft Server (nichtseb)
### Description
> Santa likes to play minecraft. His favorite version is 1.16. For security reasons, the server is not publicly accessible. But Santa is a little show-off, so he has an online map to brag about his fabulous building skills.
### Solution
We get a hint that the server runs on minecraft version 1.16. With a quick google search, you can find that 1.16 is a version of minecraft which is vulnerable to the log4shell vulnerabiliy. To abuse it, you can use [log4j-shell-poc](https://github.com/kozmer/log4j-shell-poc). On the system, you can find that you need to escalate your priviledges to get the flag. When looking for setuid binary, you will find a binary in a directory called santas-workshop. When looking at the source code, you can notice that the code just opens /bin/bash. But this does not give a root shell as bash by default drops the priviledges on startup. But you can just replace bash with your own binary which gets a root shell.
```c
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
void main() {
  setuid(0);
  seteuid(0);
  setreuid(0, 0);
  char *command = "/bin/sh";
  char *args[] = {command, "-p", NULL};
  execve(command, args, NULL);
}
```
For the lazy like me, you can find a complete solve script [here](solve.py), which performs the log4shell exploit and the privEsc automatically.
Flag: **HV23{d0n7_f0rg37_70_upd473_k1d5}**