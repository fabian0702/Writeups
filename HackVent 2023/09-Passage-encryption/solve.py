from scapy.all import *
 
for cpacket in PcapReader('secret_capture.pcapng'):
    if cpacket[IP].src == '192.168.1.12' and cpacket[TCP].sport > 56700:
        print(chr(cpacket[TCP].sport - 56700), end='')