![Ad Exchange Buyer API](https://www.google.com/images/icons/product/doubleclick-32.gif)

# Unoffical Ad Exchange Buyer API v1.3 Samples for .NET  

## API Description

Accesses your bidding-account information, submits creatives for validation, finds available direct deals, and retrieves performance reports.

[Offical Documentation](https://developers.google.com/ad-exchange/buyer-rest)

## Sample Description

These samples show how to access the [Ad Exchange Buyer API v1.3](https://developers.google.com/ad-exchange/buyer-rest) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.AdExchangeBuyer.v1.3](https://www.nuget.org/packages/Google.Apis.AdExchangeBuyer.v1.3)
Install Command: PM>  Install-Package Google.Apis.AdExchangeBuyer.v1.3

```
PM> Install-Package Google.Apis.AdExchangeBuyer.v1.3
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.AdExchangeBuyer.v1.3.AdExchangeBuyerService.Scope.AdExchangeBuyerReadonly };
var service = GoogleSamplecSharpSample.AdExchangeBuyerv1.3.Auth.Oauth2Example.GetAdExchangeBuyerService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.AdExchangeBuyerv1.3.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.AdExchangeBuyer.v1.3.AdExchangeBuyerService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.AdExchangeBuyerv1.3.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
