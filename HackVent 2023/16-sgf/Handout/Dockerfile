FROM docker.io/library/ubuntu:23.04

RUN apt update && apt -y upgrade
RUN apt install -y socat

COPY . .

RUN chmod +x vuln
RUN chmod +x magic.sh

ENTRYPOINT ["socat", "TCP-LISTEN:5000,reuseaddr,fork", "EXEC:\"./vuln\""]
