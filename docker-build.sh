#!/bin/bash

docker build -t truemark/dotnet-newrelic-app1:latest -f app1/Dockerfile .
docker build -t truemark/dotnet-newrelic-app2:latest -f app2/Dockerfile .
