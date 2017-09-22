![Google Compute Engine Instance Group Manager API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google Compute Engine Instance Group Manager API v1beta2 Samples for .NET  

## API Description

[Deprecated. Please use Instance Group Manager in Compute API] Provides groups of homogenous Compute Engine instances.

[Offical Documentation](https://developers.google.com/compute/docs/instance-groups/manager/v1beta2)

## Sample Description

These samples show how to access the [Google Compute Engine Instance Group Manager API v1beta2](https://developers.google.com/compute/docs/instance-groups/manager/v1beta2) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.replicapool.v1beta2](https://www.nuget.org/packages/Google.Apis.replicapool.v1beta2)
Install Command: PM>  Install-Package Google.Apis.replicapool.v1beta2

```
PM> Install-Package Google.Apis.replicapool.v1beta2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.replicapool.v1beta2.replicapoolService.Scope.replicapoolReadonly };
var service = GoogleSamplecSharpSample.replicapoolv1beta2.Auth.Oauth2Example.GetreplicapoolService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.replicapoolv1beta2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.replicapool.v1beta2.replicapoolService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.replicapoolv1beta2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
