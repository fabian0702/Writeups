## [HV23.18] Evil USB (coderion)
### Description
> An engineer at SantaSecCorp has found a suspicious device stuck in the USB port of his computer. It doesn't seem to work anymore, but we managed to dump the firmware for you. Please help us find out what the device did to their computer.
### Solution
When looking at the disassembly of the firmware, you can find that the firmware xores some memory with 0x69 and then writes the string with the simulated keyboard. Sadly the challenge author thought about just putting the firmware on a board and he added a 16h delay to the code. But we can actually just xor the whole firmware with 0x69.
```py
with open("./firmware.elf", "rb") as f:
    data = f.read()

with open("./base64.elf", "wb") as f:
    for byte in data:
        f.write(bytes([byte ^ 0x69]))
```
But we do not just jet get the flag. Instead we get we find a base64 encoded string. Decoding that string, we get a github gist which contains contains bash code to download a image. ![img](cat.png)    But where is the flag? It turns out the flag can be found with exiftool, as it is just in the comment field of the image.   
Flag: **HV23{4dru1n0_1s_fun}**  