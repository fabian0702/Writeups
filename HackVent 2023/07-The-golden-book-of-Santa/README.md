## [HV23.07] The golden book of Santa (darkstar)
### Decription
> An employee found out that someone is selling secret information from Santa's golden book. For security reasons, the service for accessing the book was immediately stopped and there is now only a note about the maintenance work. However, it still seems possible that someone is leaking secret data.

> Hint #1: It is recommended to initiate a direct connection to the server without any proxy in between

> Hint #2: You should stop spamming connections because you already have everything you need
### Solution
When looking at the chunk headers of the received image, you can notice that the chunk sizes look strange. Infact if you ignore the first digit of the chunksizes and decode them to ascii, you will receive the flag.  

```python
from pwn import *

# r = remote('xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.rdocker.vuln.land', 80)
# r.sendline(b'')
# content = r.recvall()
# with open('response', 'wb') as f:
#     f.write(content)

with open('response', 'rb') as f:
    content = f.read()

print('H', end='')
for chunk in content.split(b'\r\n')[2:]:
    if len(chunk) < 10 and len(chunk) > 1:
        print(chr(int(chunk[1:], 16)), end='')
print('')
```
Flag: **HV23{here_is_your_gift_in_small_pieces}**