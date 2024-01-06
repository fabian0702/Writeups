FROM ubuntu:22.04

# install nc
RUN apt-get update && apt-get install -y netcat && export ADMIN_PASSWORD=salami

WORKDIR /app
COPY . /app

ENTRYPOINT ["bash", "bask.sh"]