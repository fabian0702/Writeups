## [HV23.14] Crypto Dump (LogicalOverflow)
### Description
> To keep today’s flag save, Santa encrypted it, but now the elf cannot figure out how to decrypt it.  
> The tool just crashes all the time. Can you still recover the flag?
### Solution
After reversing the binary, you can notice that the encoded flag is located in memory pointed at by r13 and the key is memory pointed at by r13. Then you can just extract the key and encrypted flag and feed it to the programm to get the decrypted flag. Nicely enought pwntools has a convenient Corefile class which can parse and read such a file.
```py
from pwn import *

core = Corefile('./dump')               # Read corefile

flagAddress = core.registers['r13']     # Get key and data address
keyAddress = core.registers['r15']

flagData = core.read(flagAddress, 43)   # Read key and data from memory
keyData = core.read(keyAddress, 32)

with open('flag.enc', 'wb') as f:       # create necessary files
    f.write(flagData)

with open('key', 'wb') as f:
    f.write(keyData)

p = process('./flagsave ./flag.enc d', shell=True)      # Decrypt flag
p.wait()

with open('out', 'rb') as f:
    print('\nFlag:', f.read().decode())
```

Flag: **HV23{17's_4ll_ri6h7_7h3r3}**