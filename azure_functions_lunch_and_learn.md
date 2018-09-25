# Lunch & Learn
    - azure functions for the enterprise
    - 27 sept 2018

## todo
    - get project compiling/unit tests running
    - document adding unit test project
        - https://github.com/dotnet/docs/blob/master/docs/core/testing/unit-testing-with-dotnet-test.md
        - https://github.com/Azure-Samples/functions-unittesting-sample/blob/master/DotNet/DotNet.Test/HttpTriggerTest.cs
        - dotnet new xunit
        - dotnet new sln
        - dotnet sln add reference
        - dotnet add package Moq
        - dotnet test

## Topics
    - Overview of common enterprise tasks and how functions can replace them
    - Procedures
    - CI/CD of functions
    - Dependency-injecting and unit testing functions
    - Using a function to host a front-end

## Overview of Common Enterprise Tasks and How Functions Can Replace Them
    - topics TBD (find video?)
    - cron job --> timer trigger
    - web api --> http trigger
    - sql database --> cosmosdb?

### Procedures
    - dotnet core installation
        - https://www.microsoft.com/net/learn/dotnet/hello-world-tutorial
    - create new http trigger function
        - azure functions vscode extension
        - create project first
        - then create new function app
        - dotnet add package AzureFunctions.Autofac
        - dotnet add package Twilio
    - get information from https://www.twilio.com/console
    - curl request to test local
        - curl -i -H "Accept: application/json" -H "Content-Type: application/json" -X GET http://localhost:7071/api/pipeline_results_http_trigger?name=Keegan_Campbell_MD | json

## Functions CI/CD
    - https://passos.com.au/enterprise-azure-functions-3/
    - basic arm template. create and push and then copy from azure and then trim down

## Dependency-injecting and Unit Testing Functions
    - https://passos.com.au/azure-functions-dependency-injection/
    - talk about AutoFAC and built-in in order to kill time
    - AzureFunctions.Autofac v3.0.5
    - Microsoft.Net.SDK.Functions v.1.0.22
    - Twilio v5.17.0

## Using a Function to Host a Front-end
    - https://passos.com.au/serving-angular-app-from-azure-functions/
    - introduce azure storage explorer
        - https://azure.microsoft.com/en-us/features/storage-explorer/

## Questions
    - how to handle multiple endpoints?
        - different function solutions?
        - multiple functions in same solutions?
    - how to have functions call other functions?
        - demo queues
        - logic apps?
        - other function URLs in configuration?

## To Look Up Later
    - twilio pricing
        - $1/number/month
        - sms price?

## Miscellaneous

https://blogs.msdn.microsoft.com/appserviceteam/2017/09/25/develop-azure-functions-on-any-platform/

```
# for release pipeline
# Invoke Azure Function
# Invoke an Azure Function as a part of your pipeline.
- task: AzureFunction@1
  inputs:
    function: 
    key: 
    #method: 'POST' # Options: oPTIONS, gET, hEAD, pOST, pUT, dELETE, tRACE, pATCH
    #headers: '{Content-Type:application/json, PlanUrl: $(system.CollectionUri), ProjectId: $(system.TeamProjectId), HubName: $(system.HostType), PlanId: $(system.PlanId), JobId: $(system.JobId), TimelineId: $(system.TimelineId), TaskInstanceId: $(system.TaskInstanceId), AuthToken: $(system.AccessToken)}' 
    #queryParameters: # Optional
    #body: # Required when method != GET && Method != HEAD
    #waitForCompletion: 'false' # Options: true, false
    #successCriteria: # Optional
```