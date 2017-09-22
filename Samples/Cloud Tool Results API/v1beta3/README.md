![Cloud Tool Results API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Cloud Tool Results API v1beta3 Samples for .NET  

## API Description

Reads and publishes results from Firebase Test Lab.

[Offical Documentation](https://firebase.google.com/docs/test-lab/)

## Sample Description

These samples show how to access the [Cloud Tool Results API v1beta3](https://firebase.google.com/docs/test-lab/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.ToolResults.v1beta3](https://www.nuget.org/packages/Google.Apis.ToolResults.v1beta3)
Install Command: PM>  Install-Package Google.Apis.ToolResults.v1beta3

```
PM> Install-Package Google.Apis.ToolResults.v1beta3
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.ToolResults.v1beta3.ToolResultsService.Scope.ToolResultsReadonly };
var service = GoogleSamplecSharpSample.ToolResultsv1beta3.Auth.Oauth2Example.GetToolResultsService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.ToolResultsv1beta3.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.ToolResults.v1beta3.ToolResultsService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.ToolResultsv1beta3.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
