echo stop all containers:
docker kill $(docker ps -q)

echo remove all containers
docker rm $(docker ps -a -q)

echo remove all docker images
docker rmi $(docker images -q)

echo pull image from repository
docker login -u $(dockerhub_u) -p $(dockerhub_p)

echo info of the image $(Build.BuildNumber)
docker pull $(dockerhub_u)/$(dockerhub_repos):$(Build.BuildNumber)

echo run the image
docker run -d -p 80:80 --name  $(dockername)  $(dockerhub_u)/$(dockerhub_repos):$(Build.BuildNumber)