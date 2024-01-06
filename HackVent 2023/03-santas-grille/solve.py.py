# A modified version of https://github.com/Merricx/blasto/tree/master

import random, math

def gen_key(numkey,size):

	key = [[0 for _ in range(size)] for _ in range(size)]
	for i in numkey:
		key[int(i)//size][int(i)%size] = 1

	return key

def score_text(text):

	score = 1
	if text[0] == 'H':
		score*=2
	if text[1] == 'V':
		score*=2
	if text[2] == '2':
		score*=2
	if text[3] == '3':
		score*=2
	if text[4] == '{':
		score*=2
	if text[-1] == '}':
		score*=2
	
	if text.startswith('HV23{') and text[-1] == '}':
		print('Flag:', text)
		exit()

	return score

def rot90(key, size):

	new_key = []
	k = 0

	for i in range(size-1,-1,-1):
		new_key.append([])
		for j in range(0, size):
			new_key[k].append(key[j][i])
		k += 1

	return new_key

def readCipher(cipher, key, size):

	plain = ""
	index = 0
	for i in range(size):
		for j in range(size):
			if key[i][j] == 1:
				plain += cipher[index]
			index += 1

	return plain

def decrypt(ciphertext, key):

	result = ""
	size = int(math.sqrt(len(ciphertext)))
	key = key.split(",")
	key = gen_key(key, size)

	for _ in range(4):
		result += readCipher(ciphertext, key, size)
		key = rot90(key, size)


	return result

def determine_key(size):

	total_square = (size*size)-1
	max_row  = size-1
	all_key = []
	count = 0
	val1 = 0
	val3 = total_square
	addition = 2
	while max_row >= 1:
		val2 = max_row + val1
		val4 = val3 - max_row
		for _ in range(max_row):
			all_key.append([])
			all_key[count].append(val1)
			all_key[count].append(val2)
			all_key[count].append(val3)
			all_key[count].append(val4)
			count += 1
			val1 += 1
			val2 += size
			val3 -= 1
			val4 -= size
		max_row -= 2
		val1 += addition
		val3 -= addition
		addition += 2

	return all_key

def init_key(size):

	possible_key = determine_key(size)
	key = []

	for i in range(len(possible_key)):
		key.append(str(possible_key[i][random.randrange(0,4)]))

	return ",".join(key)

def change_key(key, all_key):

	new_key = key.split(",")
	randnum1 = random.randrange(0,len(new_key))
	randnum2 = random.randrange(0,len(new_key))
	new_key[randnum1] = str(all_key[randnum1][random.randrange(0,4)])
	new_key[randnum2] = str(all_key[randnum2][random.randrange(0,4)])

	return ",".join(new_key)

result = {'key':'','plain':'','score':''}

def hill_climbing(cipher_text):
	size = int(math.sqrt(len(cipher_text)))
	all_key = determine_key(size)
	parent_key = init_key(size)

	parent_score = score_text(decrypt(cipher_text, parent_key))

	while True:
		child_key = change_key(parent_key, all_key)
		child_score = score_text(decrypt(cipher_text, child_key))

		if (child_score > parent_score):
			parent_score = child_score
			parent_key = child_key

hill_climbing('8ctk32rHVr2y 0v2en3_}3h{m')