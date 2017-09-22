![Replica Pool API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Replica Pool API v1beta1 Samples for .NET  

## API Description

The Replica Pool API allows users to declaratively provision and manage groups of Google Compute Engine instances based on a common template.

[Offical Documentation](https://developers.google.com/compute/docs/replica-pool/)

## Sample Description

These samples show how to access the [Replica Pool API v1beta1](https://developers.google.com/compute/docs/replica-pool/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.replicapool.v1beta1](https://www.nuget.org/packages/Google.Apis.replicapool.v1beta1)
Install Command: PM>  Install-Package Google.Apis.replicapool.v1beta1

```
PM> Install-Package Google.Apis.replicapool.v1beta1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.replicapool.v1beta1.replicapoolService.Scope.replicapoolReadonly };
var service = GoogleSamplecSharpSample.replicapoolv1beta1.Auth.Oauth2Example.GetreplicapoolService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.replicapoolv1beta1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.replicapool.v1beta1.replicapoolService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.replicapoolv1beta1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
