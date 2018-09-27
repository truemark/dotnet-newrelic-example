#!/bin/bash

docker-compose -p dotnet-newrelic-example stop
docker-compose -p dotnet-newrelic-example rm -f
docker image rm truemark/dotnet-newrelic-app1:latest
docker image rm truemark/dotnet-newrelic-app2:latest