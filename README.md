# Distributed .NET Core

![DevMentors](https://github.com/devmentors/DNC-DShop/blob/master/assets/devmentors_logo.png)

**What is Distributed .NET Core?**
----------------

It's an open source project (and a course available soon at [devmentors.io](https://devmentors.io)), providing in-depth knowledge about building microservices using [.NET Core](https://www.microsoft.com/net/learn/get-started-with-dotnet-tutorial) framework and variety of tools. One of the goals, was to create a cloud agnostic solution, that you shall be able to run anywhere. 

We encourage you to join our [Discourse](https://www.discourse.org) forum available at [forum.devmentors.io](https://forum.devmentors.io).

For this particular course, please have a look at the topics being discussed under this [category](https://forum.devmentors.io/c/courses/distributed-dotnet-core).

**What is DShop.Api?**
----------------

DShop.Api provides an API gateway to the [DShop](https://github.com/devmentors/DNC-DShop) solution.

|Branch             |Build status                                                  
|-------------------|-----------------------------------------------------
|master             |[![master branch build status](https://api.travis-ci.org/devmentors/DNC-DShop.Api.svg?branch=master)](https://travis-ci.org/devmentors/DNC-DShop.Api)
|develop            |[![develop branch build status](https://api.travis-ci.org/devmentors/DNC-DShop.Api.svg?branch=develop)](https://travis-ci.org/devmentors/DNC-DShop.Api/branches)


**How to start the application?**
----------------

Service can be started locally via `dotnet run` (executed in the `/src/DShop.Api` directory) or `./scripts/dotnet-run.sh` shell script, by default it will be available under http://localhost:5000.

You can also run the application using [Docker](https://www.docker.com) `docker run --name api -p 5000:5000 --network dshop-network devmentors/dshop.api` (include `-d` to run the container in the background).

It is required to have the basic infrastructure up and running first ([RabbitMQ](https://www.rabbitmq.com), [MongoDB](https://www.mongodb.com) and [Redis](https://redis.io)) in the same docker network named `dshop-network`. Services can be started using [Docker Compose](https://docs.docker.com/compose) (and [this file](https://github.com/devmentors/DNC-DShop/blob/master/compose/docker-compose-infrastructure.yml)) as described [here](https://github.com/devmentors/DNC-DShop).

**What HTTP requests can be sent to the API?**
----------------

You can find the list of all HTTP requests in `DShop.rest` file placed in the root folder of repository ([here](https://github.com/devmentors/DNC-DShop.Api/blob/master/DShop.rest)). 
This file is compatible with [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) plugin for [Visual Studio Code](https://code.visualstudio.com). 
