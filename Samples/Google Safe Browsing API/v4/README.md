![Google Safe Browsing API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Safe Browsing API v4 Samples for .NET  

## API Description

Enables client applications to check web resources (most commonly URLs) against Google-generated lists of unsafe web resources.

[Offical Documentation](https://developers.google.com/safe-browsing/)

## Sample Description

These samples show how to access the [Google Safe Browsing API v4](https://developers.google.com/safe-browsing/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.safebrowsing.v4](https://www.nuget.org/packages/Google.Apis.safebrowsing.v4)
Install Command: PM>  Install-Package Google.Apis.safebrowsing.v4

```
PM> Install-Package Google.Apis.safebrowsing.v4
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.safebrowsing.v4.safebrowsingService.Scope.safebrowsingReadonly };
var service = GoogleSamplecSharpSample.safebrowsingv4.Auth.Oauth2Example.GetsafebrowsingService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.safebrowsingv4.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.safebrowsing.v4.safebrowsingService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.safebrowsingv4.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
