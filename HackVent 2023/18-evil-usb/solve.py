#!/usr/bin/python3

from re import findall
from base64 import b64decode
from requests import get

with open("./firmware.elf", "rb") as f:
    data = f.read()

decodedData = bytes([byte ^ 0x69 for byte in data])

base64data = findall(b'echo (.+?) >', decodedData)[0]

stage1 = b64decode(base64data.decode())

with open("./homework.txt", "wb") as f:
    f.write(stage1)

url1 = findall(b'wget (.+?) -', stage1)[0]
stage2 = get(url1).content

with open("./gistfile1.txt", "wb") as f:
    f.write(stage2)

url2 = findall(b'wget (.+?) -', stage2)[0]
stage3 = b64decode(get(url2).content)

with open("./cat.png", "wb") as f:
    f.write(stage3)

flag = findall(b'HV23{.+?}', stage3)[0].decode()
print(f'Flag: {flag}')