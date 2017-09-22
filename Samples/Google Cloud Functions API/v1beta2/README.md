![Google Cloud Functions API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Cloud Functions API v1beta2 Samples for .NET  

## API Description

API for managing lightweight user-provided functions executed in response to events.

[Offical Documentation](https://cloud.google.com/functions)

## Sample Description

These samples show how to access the [Google Cloud Functions API v1beta2](https://cloud.google.com/functions) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.CloudFunctions.v1beta2](https://www.nuget.org/packages/Google.Apis.CloudFunctions.v1beta2)
Install Command: PM>  Install-Package Google.Apis.CloudFunctions.v1beta2

```
PM> Install-Package Google.Apis.CloudFunctions.v1beta2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.CloudFunctions.v1beta2.CloudFunctionsService.Scope.CloudFunctionsReadonly };
var service = GoogleSamplecSharpSample.CloudFunctionsv1beta2.Auth.Oauth2Example.GetCloudFunctionsService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.CloudFunctionsv1beta2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.CloudFunctions.v1beta2.CloudFunctionsService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.CloudFunctionsv1beta2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
