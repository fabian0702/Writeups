import cv2
from re import findall

img = cv2.imread('chall.png').tolist()

out = ''
for line in range(len(img[0])):
    out += ''.join([chr(max(min(x[line][0] ^ x[line][2], 126), 32)) for x in img])

print('Day 11:', findall(r'(HV23\{\w.*?\})', out)[0])

out = ''.join(findall(r'[01]', out.replace('Never gonna give you up.', '0').replace('Never gonna let you down.', '1')))
print('Hidden 2:', findall(r'(HV23\{\w.*?\})',''.join([chr(int(out[i:i+8], 2)) for i in range(0, len(out), 8)]))[0])