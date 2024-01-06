#!/usr/bin/env python3

from pwn import *

exe = ELF('bowser.elf')

p = gdb.debug(['bowser.elf', 'mario'], exe='bowser.elf', api=True, gdbscript='''
break *main+319
continue &''')
p.gdb.execute('print flag')
