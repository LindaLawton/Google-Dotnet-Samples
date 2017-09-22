![APIs Discovery Service](http://www.google.com/images/icons/feature/filing_cabinet_search-g32.png)

# Unoffical APIs Discovery Service v1 Samples for .NET  

## API Description

Provides information about other Google APIs, such as what APIs are available, the resource, and method details for each API.

[Offical Documentation](https://developers.google.com/discovery/)

## Sample Description

These samples show how to access the [APIs Discovery Service v1](https://developers.google.com/discovery/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.discovery.v1](https://www.nuget.org/packages/Google.Apis.discovery.v1)
Install Command: PM>  Install-Package Google.Apis.discovery.v1

```
PM> Install-Package Google.Apis.discovery.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.discovery.v1.discoveryService.Scope.discoveryReadonly };
var service = GoogleSamplecSharpSample.discoveryv1.Auth.Oauth2Example.GetdiscoveryService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.discoveryv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.discovery.v1.discoveryService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.discoveryv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
