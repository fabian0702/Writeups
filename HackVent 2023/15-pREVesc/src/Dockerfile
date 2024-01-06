FROM ubuntu:23.10

# Copy the malicious bin
COPY shadow/src/passwd /usr/bin/passwd
RUN chown root:root /usr/bin/passwd && chmod 4755 /usr/bin/passwd

# Install useful tools
RUN apt update && apt install -y vim curl wget binutils radare2 git openssh-server

# Create challenge user
RUN useradd -m -s /bin/bash challenge && \
    echo "challenge:challenge" | chpasswd

COPY flag.txt /root/flag.txt
RUN chmod 400 /root/flag.txt

RUN sed -i 's/#PasswordAuthentication yes/PasswordAuthentication yes/' /etc/ssh/sshd_config
EXPOSE 22
CMD ["/usr/sbin/sshd", "-D"]
