# Pivotal Cloud Foundry 101 Workshop

This one day hands-on classroom style session will provide developers (and operators) with hands on experience with Pivotal Cloud Foundry concepts, architecture and fundamentals of pushing code and building applications. The session includes presentations, demos and hands on labs.

## Getting Started

The source code for all the labs can be cloned to your local desktop using the following git command.

* git clone https://github.com/pivotal-nyc/pcf-workshop-dotnet.git

### Prerequisites

The following tools are required to be installed on the local machine. 

* [cf cli](https://github.com/cloudfoundry/cli#downloads)
* [git](https://git-scm.com/downloads)

The environment is...

## Course Materials

It is recommended to follow the labs in sequence, but 

### Intro

* Login to lab environment with the following details.

### [Lab 1](https://github.com/pivotal-nyc/pcf-workshop-dotnet/tree/master/labs/pcf-workshop-dotnet-core-lab01) - Beginner

* Step 1, describes how to quickly get help for any CLI command.
* Step 2, demonstrates pushing an app using the CLI only.
* Step 3, demonstrates pushing an app using the CLI with a manifest file.
* Step 4, demonstrates scaling an app with more disk space, memory, and running instance count.

### [Lab 2](https://github.com/pivotal-nyc/pcf-workshop-dotnet/tree/master/labs/pcf-workshop-dotnet-core-lab02) - Intermediate

* Step 1, deploy an ASP.NET 2.0 Web API project.
* Step 2, create and bind an auto-scaler service.
* Step 3, configure the service in Apps Manager.
* Step 4, test the elasticity of the app increasing and decreasing load.

### [Lab 3](https://github.com/pivotal-nyc/pcf-workshop-dotnet/tree/master/labs/pcf-workshop-dotnet-core-lab03) - Intermediate

* Step 1, forcibly kill one app instance out of three to observe the platform restore it automatically.
* Step 2, demonstrates a blue-green deployment to execute a zero-downtime deployment.