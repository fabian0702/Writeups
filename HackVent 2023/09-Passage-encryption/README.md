## [HV23.09] Passage encryption (dr_nick)
### Decription
> Santa looked at the network logs of his machine and noticed that one of the elves browsed a weird website. He managed to get the pcap of it, and it seems as though there is some sensitive information in there?!
### Solution
When viewing the pcap file in wireshark the port number of the sender looked really weird. And infact when extracting these ports and substracting 56700 you can notice that those numbers look like ascii. When decoding the numbers, the flag is revealed.   
```python
from scapy.all import *
 
for cpacket in PcapReader('secret_capture.pcapng'):
    if cpacket[IP].src == '192.168.1.12' and cpacket[TCP].sport > 56700:
        print(chr(cpacket[TCP].sport - 56700), end='')
print('')
```
Flag: **HV23{Lo0k1ng_for_port5_no7_do0r$}**