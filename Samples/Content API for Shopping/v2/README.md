![Content API for Shopping](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Content API for Shopping v2 Samples for .NET  

## API Description

Manages product items, inventory, and Merchant Center accounts for Google Shopping.

[Offical Documentation](https://developers.google.com/shopping-content)

## Sample Description

These samples show how to access the [Content API for Shopping v2](https://developers.google.com/shopping-content) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.ShoppingContent.v2](https://www.nuget.org/packages/Google.Apis.ShoppingContent.v2)
Install Command: PM>  Install-Package Google.Apis.ShoppingContent.v2

```
PM> Install-Package Google.Apis.ShoppingContent.v2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.ShoppingContent.v2.ShoppingContentService.Scope.ShoppingContentReadonly };
var service = GoogleSamplecSharpSample.ShoppingContentv2.Auth.Oauth2Example.GetShoppingContentService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.ShoppingContentv2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.ShoppingContent.v2.ShoppingContentService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.ShoppingContentv2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
