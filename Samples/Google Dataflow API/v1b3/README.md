![Google Dataflow API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Dataflow API v1b3 Samples for .NET  

## API Description

Manages Google Cloud Dataflow projects on Google Cloud Platform.

[Offical Documentation](https://cloud.google.com/dataflow)

## Sample Description

These samples show how to access the [Google Dataflow API v1b3](https://cloud.google.com/dataflow) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.dataflow.v1b3](https://www.nuget.org/packages/Google.Apis.dataflow.v1b3)
Install Command: PM>  Install-Package Google.Apis.dataflow.v1b3

```
PM> Install-Package Google.Apis.dataflow.v1b3
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.dataflow.v1b3.dataflowService.Scope.dataflowReadonly };
var service = GoogleSamplecSharpSample.dataflowv1b3.Auth.Oauth2Example.GetdataflowService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.dataflowv1b3.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.dataflow.v1b3.dataflowService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.dataflowv1b3.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
