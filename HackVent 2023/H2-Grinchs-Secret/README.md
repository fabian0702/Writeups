## [HV23.H2] Grinch's Secret
### Decription
> Santa usually only gifts one present per kid, but one of his elves accidentally put two presents in the bag for a single kid! Somewhere in the medium challenges, you can find the second gift.
### Solution
This Flag was actually inside day 11. When looking at the rest of the text, you could notice that the pattern of ```Never gonna give you up``` and ```Never gonna let you down``` are strange. Actually they look like binary. And infact if we replace the ```Never gonna give you up``` with 0 and ```Never gonna let you down``` with 1, and decode them to ascii, we find the second flag.   
   
solve.py:   
```py
import cv2
from re import findall

img = cv2.imread('chall.png').tolist()

out = ''
for line in range(len(img[0])):
    out += ''.join([chr(max(min(x[line][0] ^ x[line][2], 126), 32)) for x in img])

out = ''.join(findall(r'[01]', out.replace('Never gonna give you up.', '0').replace('Never gonna let you down.', '1')))
print('Hidden 2:', findall(r'(HV23\{\w.*?\})',''.join([chr(int(out[i:i+8], 2)) for i in range(0, len(out), 8)]))[0])
```

Flag: **HV23{h1dden_r1ckr011}**