## [HV23.01] A letter from Santa (coderion)
### Description
>Finally, after 11 months of resting, Santa can finally send out his presents and challenges again. He was writing a letter to his youngest baby elf, who's just learning his ABC/A-Z's. Can you help the elf read the message?
### Overview
Simple Flask webapp
you can chose a letter in the drop-down and chose a string to replace. Some letters have black background some white.
### Solution
If you chose 'a' in the dropdown and specify '  ' as a replacement, you might realize that the rendered text looks like the first line of a qrcode. If you look into the sources you can see that every element with the class a has a black background and every element with b has a light background. Thy python code below reads the template extract all elements and generates a ascii qrcode in your terminal.
```python
import re
with open('./templates/santa.j2', 'r') as f:
    content = f.read()

combinations = re.findall(r"'([ab])'>{{([a-z])}}", content)
combinations.sort(key=lambda x: x[-1])
code = ''.join(['  ' if combination[0] == 'a' else '██' for combination in combinations])
for i in range(0, 1250, 50):
    print(code[i:i+50])
```
Flag: **HV23{qr_c0des_fun}**