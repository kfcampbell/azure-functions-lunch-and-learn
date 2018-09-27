# Lunch & Learn
    - azure functions for the enterprise
    - 27 sept 2018

## Topics
    - Overview of common enterprise tasks and how functions can replace them
    - Framework installation
    - Dependency-injecting and unit testing functions
    - CI/CD of functions
    - AppInsights/Metrics
    - Using a function to host a front-end

## Overview of Common Enterprise Tasks and How Functions Can Replace Them
    - cron job --> timer trigger
    - web api --> http trigger
    - queue processor --> queue trigger/eventhub trigger
    - shell scripts --> powershell
    - sql database --> cosmosdb/azure sql server

### Frameworks/Installations
    - dotnet core installation
        - https://www.microsoft.com/net/learn/dotnet/hello-world-tutorial
    - azure storage explorer
        - https://azure.microsoft.com/en-us/features/storage-explorer/
    
## Dependency-injecting and Unit Testing Functions
    - create new http trigger function
        - azure functions vscode extension
        - create project first (in subdirectory to avoid package conflicts between tests and implementation)
        - then create new function app
            - access rights: anonymous
        - packages to add
            - AzureFunctions.Autofac v3.0.5
            - Twilio v5.17.0
    - get information from https://www.twilio.com/console
    - curl request to test local
        - curl -i -H "Accept: application/json" -H "Content-Type: application/json" -X GET http://localhost:7071/api/pipeline_results_http_trigger?name=Keegan_Campbell_MD | json
    - add unit test project
        - dotnet new mstest
        - dotnet new sln
        - dotnet sln add {path_to_test_csproj} // from outer directory
        - dotnet add reference {path_to_implementation}
        - dotnet test
    - packages to add
        - Moq v4.10.0
    
## Functions CI/CD
    - basic arm template. create and push and then copy from azure and then trim down
    - show build/release process
        - build
            - https://dev.azure.com/keegancampbell/azure-functions-for-enterprise/_build?definitionId=2
        - release
            - https://dev.azure.com/keegancampbell/azure-functions-for-enterprise/_releases2?definitionId=1&view=mine&_a=releases
    - gates
        - create service connection
            - type: generic
            - url: function URL
            - username: garbage
            - password: garbage
        - url suffix/params are empty
        - get method
        - leave params
    - potential errors
        - 500 errors on deployment due to autofac
            - restart function

## AppInsights
    - live metrics stream
    - logs delayed 5min
    - show failures/requests
    - can see logs when manually running function from portal

## Using a Function to Host a Front-end
    - https://frontend-react-app.azurewebsites.net/
    - procedure
        - create function app
            - windows
            - separate resource group
        - create 3 proxies
            - react
                - for homepage
                - backend url: {function storage url}/{function storage folder}/index.html
                - route template: /{*path}
            - static
                - for static assets
                - backend url: {function storage url}/{function storage folder}/static/{file}
                - route template: /static/{*file}
            - files
                - for service worker, favicon, manifests, etc.
                - backend url: {function storage url}/{function storage folder}/{file}.{ending}
                - route template: {file}.{ending}
    - pros
        - easy to set up
        - quick to get off the group
        - easy POC
        - pay for traffic you use
        - easy scale up/down due to serverless architecture
    - cons
        - cold start times
            - 'always on' functionality combats this
        - not suitable for complex projects
    - possible errors
        - 500 errors hitting site
            - make sure backend urls are actually from blob storage
            - make sure you're on windows in a new resource group
    
## Questions
    - how to handle multiple endpoints?
        - different function solutions
        - multiple functions in same solutions
            - advantage: shared code/models/class libraries
    - how to have functions call other functions?
        - demo queues
        - logic apps
        - other function URLs in configuration
    - secret management
        - how to show?
        - enough time to show?

## Helpful Links
    - ci/cd
        - https://passos.com.au/enterprise-azure-functions-3/
    - dependency injection
        - https://passos.com.au/azure-functions-dependency-injection/
    - unit testing
        - https://github.com/dotnet/docs/blob/master/docs/core/testing/unit-testing-with-dotnet-test.md
        - https://github.com/Azure-Samples/functions-unittesting-sample/blob/master/DotNet/DotNet.Test/HttpTriggerTest.cs
    - functions hosting frontend
        - https://passos.com.au/serving-angular-app-from-azure-functions/
        - https://blog.cloudboost.io/host-spa-with-azure-functions-62e8b55a23e5
    - miscellaneous
        - https://blogs.msdn.microsoft.com/appserviceteam/2017/09/25/develop-azure-functions-on-any-platform/

## Miscellaneous
    - twilio pricing
        - $1/number/month
        - sms: $0.0075/outbound message (75 cents/100 messages)