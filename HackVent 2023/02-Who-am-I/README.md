# [HV23.02] Who am I? (explo1t)
## Description
>Have you ever wished for an efficient dating profile for geeks? Here's a great example:  
>   
>```G d--? s+: a+++ C+++$ UL++++$ P--->$ L++++$ !E--- W+++$ N* !o K--? w O+ M-- V PS PE Y PGP++++ t+ 5 X R tv-- b DI- D++ G+++ e+++ h r+++ y+++```  
  
>Flag format: ```HV23{<Firstname Lastname>}```
## Overview
By the looks of it, this is very likely a geek code profile. In the geek code [wikipedia article](https://de.wikipedia.org/wiki/Geek_Code) is a link to this [geek-code decoder](http://www.joereiss.net/geek/ungeek.html) where you can decode your geek code. Under the PGP attribute there is '*I am Philip Zimmerman*'. Given the Flag format which calls for Firstname Lastname, the flag is **HV23{Philip Zimmerman}**.