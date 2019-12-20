# WeSplitLoot #
* * *

Automatically send expenses from Revolut to Splitwise.

# Getting Started #
* * *

## Overview ##

* WeSplitLoot is a `ASP.NET Core 2.2` project with `VueJS` at frontend
* `MongoDB Atlas` is used as a database for this project
* WeSplitLoot can be run at `Docker`
  
If you are unable to run `Docker` on your machine skip to the Local Setup section.

```
git clone <WeSplitLoot_repo>
```

## Docker Setup ##
* * *
To run the Docker containers in desired environment use the command below.

#### Development environment ####
```bash
docker-compose up
```

#### Production environment ####
```bash
docker-compose -f production.yml up
```

Getting directly from Docker Hub
```bash
docker pull furyan/wesplitloot:latest
```


## Local Setup ##
* * *
  
### Technical Requirements ##

For local setup you will need:

* NodeJS `v10.13.0`
* npm `v6.4.1+`
* vue CLI `v4.1.1+`
* .NET Core CLI `2.1`

### In order to get this up and running ###

#### Development environment ####
* Invoke `npm run build-watch` in console at wmcc/frontend
* It will make build of `VueJS` application and copy it to ASP.NET Core directory (`./backend/src/ClientApp`)
* Use Visual Studio to build solution and run application
* When making changes to `VueJS` it will automatically be rebuild - you don't have to rebuild asp.net

#### Production environment ####
* Invoke `npm run build` in console
* It will make build of `VueJS` application and copy it to ASP.NET Core directory (`./backend/src/ClientApp`)
* Set environment variable to `ASPNETCORE_ENVIRONMENT=Production`
* Use Visual Studio to build solution and run application in Production environment

## Database ##
MongoDB is running at `MongoDB Atlas`

For connecting to database from shell:

* Get the latest `MongoDB Shell` compatible with your cluster `(4.2.2)`
* Add `<your Mongo Shell's download directory>/bin` to your `$PATH` variable
* Run your connection string in your command line:

```bash
mongo "mongodb+srv://archos-ezw4q.azure.mongodb.net/test"  --username <username>
```
Ask for `username` and `password` this project administrator
