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