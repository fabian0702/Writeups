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