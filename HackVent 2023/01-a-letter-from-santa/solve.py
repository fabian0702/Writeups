import re
with open('./templates/santa.j2', 'r') as f:
    content = f.read()

combinations = re.findall(r"'([ab])'>{{([a-z])}}", content)
combinations.sort(key=lambda x: x[-1])
code = ''.join(['  ' if combination[0] == 'a' else '██' for combination in combinations])
for i in range(0, 1250, 50):
    print(code[i:i+50])