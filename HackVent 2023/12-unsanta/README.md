[HV23.12] unsanta (kuyaya)
### Description
> To train his skills in cybersecurity, Grinch has played this year's SHC qualifiers. He was inspired by the cryptography challenge unm0unt41n (can be found here) and thought he might play a funny prank on Santa. Grinch is a script kiddie and stole the malware idea and almost the whole code. Instead of using the original encryption malware from the challenge though, he improved it a bit so that no one can recover his secret!
> 
> Luckily, Santa had a backup of one of the images. Maybe this can help you find the secret and recover all of Santa's lost data...?
### Solution
The mentioned malware just xores the files with a random numbers. But this numbers are not really random, infact if you know 624 consecutive numbers, you can predict every next number. Additionally with the help of Z3 it is possible to recover the seed which is what we need here. To make this possible we can use [RNGeesus](https://github.com/deut-erium/RNGeesus) from deut-erium. You can extract the random numbers from the encrypted and the backup and then give these to the solver. When decoding the long array you get the Flag.   

```py
from mersenne import BreakerPy
from Crypto.Util.number import long_to_bytes

with open('./backup/a.jpg', 'rb') as f:
    msg = f.read()

with open('./memes/a.jpg', 'rb') as f:
    enc = f.read()

key = b"".join([bytes([msg[i] ^ enc[i]]) for i in range(624*4)])
randomNumbers = [int.from_bytes(key[i:i+4], 'big') for i in range(0, 624*4, 4)]

b = BreakerPy()
recovered_seeds = b.get_seeds_python_fast(randomNumbers)
print(long_to_bytes(b.array_to_int(recovered_seeds)))
```
  
A complete solve.py can be found [here](solve.py).

Flag: **HV23{s33d_r3c0very_1s_34sy}**