## [HV23.23] Roll your own RSA (cryze)
### Description
> Santa wrote his own script to encrypt his secrets with RSA. He got inspired from the windows login where you can specify a hint for your password, so he added a hint for his own software. This won't break the encryption, will it?
### Solution
For this challenge we are given the [sourcecode](./23-/) and the [output](./23-Roll-your-own-RSA/output.txt) of one run. In the code we find that both x,y are importet from another file and are both under 1000 which seems to suggest to use bruteforce. 
```py
from secret import FLAG, x, y
import random

# D = {x∈ℕ | 0 ≤ x ≤ 1000}
# D = {y∈ℕ | 0 ≤ y ≤ 1000}
```
Indeed, you can bruteforce y quite easily as there exists only one y which fits the given output. From there i tried to solve the equation with z3 which failed due to z3 not beeing able to solve the equation in a reasonable time, but with sage it is apparently possible. But if you look closly at the generation of the hint,
```py
p = getStrongPrime(512)
q = getStrongPrime(512)

...

hint = p**3 - q**8 + polynomial_function(x=x)  
```
you can notice that the result polynomial function is quite small. Additionally it is noteworty that -q**8 is much bigger than p\*\*3. If we calculate the 8th root of the absolute part of the solution, we actually get q. From there it is trivial to calculate p from N and then implement the standart rsa algorithm.

```py
from sage.all import *

N=143306145185651132108707...
e=65537
hint=-36736786172769290028...
encrypted=7279276277823216...

q = round(abs(hint)**(1/8))

# Find p using N and q
approx_p = N // q

# Calculate phi and the decryption exponent d
phi = (p - 1) * (q - 1)
d = inverse_mod(e, phi)

# Decrypt the flag
decrypted = power_mod(encrypted, d, N)
flag = int(decrypted).to_bytes((decrypted.nbits() + 7) // 8, byteorder='big').decode()
print(flag)
```
The complete solve.sage can be found [here](./23-Roll-your-own-RSA/solve.sage)
     
Flag: **HV23{1t_w4s_4b0ut_t1m3_f0r_s0me_RSA_4g41n!}**