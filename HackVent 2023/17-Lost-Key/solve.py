#!/usr/bin/python3

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