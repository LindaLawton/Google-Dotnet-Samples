![Ad Exchange Buyer API II](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Ad Exchange Buyer API II v2beta1 Samples for .NET  

## API Description

Accesses the latest features for managing Ad Exchange accounts, Real-Time Bidding configurations and auction metrics, and Marketplace programmatic deals.

[Offical Documentation](https://developers.google.com/ad-exchange/buyer-rest/reference/rest/)

## Sample Description

These samples show how to access the [Ad Exchange Buyer API II v2beta1](https://developers.google.com/ad-exchange/buyer-rest/reference/rest/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.AdExchangeBuyerII.v2beta1](https://www.nuget.org/packages/Google.Apis.AdExchangeBuyerII.v2beta1)
Install Command: PM>  Install-Package Google.Apis.AdExchangeBuyerII.v2beta1

```
PM> Install-Package Google.Apis.AdExchangeBuyerII.v2beta1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.AdExchangeBuyerII.v2beta1.AdExchangeBuyerIIService.Scope.AdExchangeBuyerIIReadonly };
var service = GoogleSamplecSharpSample.AdExchangeBuyerIIv2beta1.Auth.Oauth2Example.GetAdExchangeBuyerIIService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.AdExchangeBuyerIIv2beta1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.AdExchangeBuyerII.v2beta1.AdExchangeBuyerIIService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.AdExchangeBuyerIIv2beta1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
