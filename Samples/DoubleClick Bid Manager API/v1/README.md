![DoubleClick Bid Manager API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical DoubleClick Bid Manager API v1 Samples for .NET  

## API Description

API for viewing and managing your reports in DoubleClick Bid Manager.

[Offical Documentation](https://developers.google.com/bid-manager/)

## Sample Description

These samples show how to access the [DoubleClick Bid Manager API v1](https://developers.google.com/bid-manager/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.DoubleClickBidManager.v1](https://www.nuget.org/packages/Google.Apis.DoubleClickBidManager.v1)
Install Command: PM>  Install-Package Google.Apis.DoubleClickBidManager.v1

```
PM> Install-Package Google.Apis.DoubleClickBidManager.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.DoubleClickBidManager.v1.DoubleClickBidManagerService.Scope.DoubleClickBidManagerReadonly };
var service = GoogleSamplecSharpSample.DoubleClickBidManagerv1.Auth.Oauth2Example.GetDoubleClickBidManagerService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.DoubleClickBidManagerv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.DoubleClickBidManager.v1.DoubleClickBidManagerService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.DoubleClickBidManagerv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
