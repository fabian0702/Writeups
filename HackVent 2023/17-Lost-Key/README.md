## [HV23.17] Lost Key (darkstar)
### Description
> After losing another important key, the administrator sent me a picture of a key as a replacement. But what should I do with it?    
> ![Alt text](./17-Lost-Key/key.png)
### Solution
When looking at the image, you can notice that there are two clearly out of place pixels. When looking with zsteg you can find in the meta Comment: ```Key Info: 0x10001```. This is clearly a hint to use RSA because 0x10001 is the defacto standart private key. When spliting the image in half, with the strange pixels at the end, and then decoding them to bytes, you will find p and q. And with these you can calculate the private key and n, to decrypt the flag.   

![flag](./17-Lost-Key/flag.png)  

```py
from PIL import Image
from Crypto.Util.number import bytes_to_long, long_to_bytes
import sys
sys.set_int_max_str_digits(0)

img = Image.open("key.png")

data = img.tobytes()
p = bytes_to_long(data[:len(data)//2])
q = bytes_to_long(data[len(data)//2:])
print(f"{p=} {q=}")

e = 0x10001
n = p * q
phi = (p-1)*(q-1)
d = pow(e, -1, phi)
print(f'{d=}')

with open("flag.enc", "rb") as f:
    enc=bytes_to_long(f.read())

flag = pow(enc, d, n)

with open('flag.png', 'wb') as f:
    f.write(long_to_bytes(flag))
```

Flag: **HV23{Thanks_for_finding_my_key}**