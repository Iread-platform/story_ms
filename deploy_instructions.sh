#! /bin/bash

DOCKER_ORGANIZATION_NAME=$1
DOCKER_IMAGE_NAME=$2

echo ======== docker images ========;
docker images --format {{.Repository}}:{{.Tag}};

echo ======== docker containers ========;
docker ps --format {{.Names}};

echo ======== last docker images of this micro service ========;
docker images -q --filter reference=${DOCKER_ORGANIZATION_NAME}/${DOCKER_IMAGE_NAME};

echo ======== remove last docker images of this micro service ========;
docker images -q --filter reference=${DOCKER_ORGANIZATION_NAME}/${DOCKER_IMAGE_NAME} | grep -q . && docker rmi $(docker images --format="{{.Repository}} {{.ID}}" |  grep "^${DOCKER_ORGANIZATION_NAME}/${DOCKER_IMAGE_NAME} " |  cut -d" " -f2 | tr "\r\n" " ") || echo Not Found Image With Name = ${DOCKER_IMAGE_NAME};
