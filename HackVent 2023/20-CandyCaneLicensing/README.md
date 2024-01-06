## [HV23.20] Santa's Candy Cane Machine (keep3r)
### Description
> As Santa wanted to start producing Candy Canes for this years christmas season, his machine wouldn't work anymore. All he got was some error message about an "expired license". Santa tried to get support from the manufacturer. Unfortunately, the company is out of business since many years.  
>  
> One of the elves already tried his luck but all he got out of the machine was a .dll!  
>  
> Can you help Santa license his Candy Cane machine and make all those kids happy for this years christmas?    
### Solution
When opening the dll in Ilspy, we can find, like the name suggests a Licence Checker. The main part of the time for this challenge was actually spent creating a python version of the licence check. This check is made of 3 distinct parts. The first part of the check converts the licence key which is given as a string to a array. Cleaned up and translated to python the function looks like this:
```py
def strToArr(strIn:str) -> list:
    if not (len(strIn) == 29 and strIn[ 5] == '-' and strIn[11] == '-' and strIn[17] == '-' and strIn[23] == '-'):
        return None
    arr = []
    for c in strIn:
        if c == '-':
            continue
        if not c in '23456789ABCDEFGHJKLMNPQRSTUVWXYZ':
            return None
        arr.append(candyMap[ord(c) & 255])
    return arr
``` 
This function already confines our searchspace a lot as the list of possible characters is not that big.

The next part "unshuffels" the array with two lookup tables.
```py
def ComputeShuffle(arr) -> int:
    num = 0
    for i in range(24):
        num += arr[i] + shuffler[i]
    num = num % 32
    return num

def UnshuffleArray(arr):
    b = ComputeShuffle(arr)
    b2 = arr[24]
    if b >= 32 or b2 >= 32:
        return None
    array = [0 for _ in range(24)]
    for i in range(24):
        array[i] = candyMixHorizontals[b2][arr[i]]
    for j in range(24):
        arr[candyMixVerticals[b][j]] = array[j]
    return arr
```
The unshuffeling is based on some constansts with are given by the ComputeShuffle and the 24th element in the input.

The last part is just converting the array into a binary form which the creator graciously alread reversed. 
```py
def arrToBin(arr):
    bin = [0 for _ in range(16)]
    num2 = arr[0] << 35 | arr[1] << 30 | arr[2] << 25 | arr[3] << 20 | arr[4] << 15 | arr[5] << 10 | arr[6] << 5 | arr[7]
    bin[0] = num2 >> 32 & 255
    bin[1] = num2 >> 24 & 255
    bin[2] = num2 >> 16 & 255
    bin[3] = num2 >> 8 & 255
    bin[4] = num2 & 255
    num2 = arr[8] << 35 | arr[9] << 30 | arr[10] << 25 | arr[11] << 20 | arr[12] << 15 | arr[13] << 10 | arr[14] << 5 | arr[15]
    bin[5] = num2 >> 32 & 255
    bin[6] = num2 >> 24 & 255
    bin[7] = num2 >> 16 & 255
    bin[8] = num2 >> 8 & 255
    bin[9] = num2 & 255
    num2 = arr[16] << 35 | arr[17] << 30 | arr[18] << 25 | arr[19] << 20 | arr[20] << 15 | arr[21] << 10 | arr[22] << 5 | arr[23]
    bin[10] = num2 >> 32 & 255
    bin[11] = num2 >> 24 & 255
    bin[12] = num2 >> 16 & 255
    bin[13] = num2 >> 8 & 255
    bin[14] = num2 & 255
    bin[15] = arr[24] << 3
    return bin
```
This binary is then converted into a struct where the various informations about the licence key is saved.

For a licence key to be valide it has to satisfy the following conditions:
```py
Expiration > 1621805003 and Generation > 1621805003 and Product == 1 and Type == 1
```
As these conditions are quite permissive, i just bruteforced the possible combinations until one worked.

This license key can then be submitted on the website to get the flag.

A complete solve.py can be found [here](solve.py).

Flag: **HV23{santas-k3ygen-m4ster}**