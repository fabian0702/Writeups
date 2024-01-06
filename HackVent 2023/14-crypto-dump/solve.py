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