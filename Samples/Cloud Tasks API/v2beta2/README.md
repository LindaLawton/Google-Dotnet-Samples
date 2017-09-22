![Cloud Tasks API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Cloud Tasks API v2beta2 Samples for .NET  

## API Description

Manages the execution of large numbers of distributed requests. Cloud Tasks is in Alpha.

[Offical Documentation](https://cloud.google.com/cloud-tasks/)

## Sample Description

These samples show how to access the [Cloud Tasks API v2beta2](https://cloud.google.com/cloud-tasks/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.CloudTasks.v2beta2](https://www.nuget.org/packages/Google.Apis.CloudTasks.v2beta2)
Install Command: PM>  Install-Package Google.Apis.CloudTasks.v2beta2

```
PM> Install-Package Google.Apis.CloudTasks.v2beta2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.CloudTasks.v2beta2.CloudTasksService.Scope.CloudTasksReadonly };
var service = GoogleSamplecSharpSample.CloudTasksv2beta2.Auth.Oauth2Example.GetCloudTasksService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.CloudTasksv2beta2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.CloudTasks.v2beta2.CloudTasksService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.CloudTasksv2beta2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
