## [HV23.06] Santa should use a password manager (wangibangi)
### Decription
> Santa is getting old and has troubles remembering his password. He said password Managers are too complicated for him and he found a better way. So he screenshotted his password   and decided to store it somewhere handy, where he can always find it and where its easy to access.
>   
> Santa recommends the volatility profile Win10x64_18362  
### Solution
As in the description mentioned, is the given file a volatility dump. Additionally there is a hint that the flag is in a screenshot. Based on this information we try to list all images.
```shell 
./vol.py -f /mnt/ain/memory.raw windows.filescan.FileScan
```
List of interesting files:
```
0x918b760e8750  \Users\santa\Pictures\wallpaper.png	216
0x918b760e88e0	\Users\santa\AppData\Local\Packages\Microsoft.Windows.Photos_8wekyb3d8bbwe\LocalState\PhotosAppBackground\wallpaper.png	216
0x918b760ed250	\Users\santa\Pictures\wallpaper.png	216
0x918b760ed3e0	\Users\santa\AppData\Local\Packages\Microsoft.Windows.Photos_8wekyb3d8bbwe\LocalState\PhotosAppBackground\wallpaper.png	216
0x918b76c517f0	\Users\santa\Pictures\wallpaper.png	216
0x918b76c54860	\Users\santa\AppData\Local\Packages\Microsoft.Windows.Photos_8wekyb3d8bbwe\LocalState\PhotosAppLockscreen\wallpaper.png	216
0x918b76c56160	\Users\santa\AppData\Local\Packages\Microsoft.Windows.Photos_8wekyb3d8bbwe\LocalState\PhotosAppLockscreen\wallpaper.png	216
0x918b771069c0	\Users\santa\Pictures\wallpaper.png	216
```
This wallpaper.png in the Pictures Folder looks quite interesting, and we can dump it by providing the address from above.
```shell 
./vol.py -f /mnt/ain/memory.raw windows.dumpfiles.DumpFiles --virtaddr 0x918b760e8750
```
We then get the following image with a qrcode which contains the flag:
![wallpaper.png](wallpaper.png)
Flag: **HV23{FANCY-W4LLP4p3r}**