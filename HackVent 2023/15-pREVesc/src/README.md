pREVesc
===
### Description
We recently changed the root password for santa as he always broke our system. However, I think he has hidden some backdoor in there. Please help us find it to save christmas!

### Solution
- Note that `/usr/bin/passwd` has been modified recently
- Reverse engineer the binary or diff it (You can use `scp` to copy it, then use something local or use the preinstalled binary)
- Notice the added `--execute` or `-E` flag that spawns `/bin/bash -p`
- Run `passwd -E`, get a root shell and read the flag at `/root/flag.txt`

### Handout
The users need to connect via SSH, credentials are `challenge:challenge`, `sshd` is running on port `22`.

There is no additional handout needed.

### Challenge category
`Reverse Engineering` and `Linux`

### Difficulty
`Medium` to `Hard`
