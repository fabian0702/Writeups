PORT=5000
sudo docker run -p $PORT:5000 --privileged $(sudo docker build -q .)
