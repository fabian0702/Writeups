## [HV23.21] Shoppinglist (fabi07)
### Description
> Santa still needs to buy some gifts, but he tends to forget things easily. That’s why he created his own application: A shopping list with state-of-the-art hacker protection.
### Solution
This challenge sadly had a really easy unintended vulnerability, but as the author i will show the intended solution here. When opening the binary in a disassembler like ghidra, you can find that the binary looks like clasical heap exploitation. There is a menu where you can chose a action and all these actions interact in some way with the heap. If you change a quantity of a item to 1337, the code leaks you the address of the win function.
```c
if(items[itemID]->nameLength==1337) 
      printf("You've found my little secret, as a reward you will get: %p\n\n", win);
``` 
Additionaly there is a bufferoverflow in the edit name functionality.
```c
gets(items[itemID]->name,items[itemID]->count+1, stdin);
``` 
Using this bufferoverflow, you can leak a libc address by firstly filling the tcache bins, then freeing a big chunk, which will go into the unsorted bins and consequently will have a libc pointer and lastly filling the space upto the address with data. When you then print the data, you have a libc pointer. When using the bufferoverflow again, you can overwrite the pointers in the items struct which gives you a arbitrary write/read. Using this read/write primitive, you can leak a stack address from the environ pointer in the libc. You can then just overwrite a return address with the win funtion and you get your shell. When printing the flag, you get a ascii qr code which contains the flag.

![flag](./21-Shoppinglist/flag.png)

A complete solve.py can be found [here](./21-Shoppinglist/solve.py).

Flag: **HV23{heap4the_win}**