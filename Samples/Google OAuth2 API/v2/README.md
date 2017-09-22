![Google OAuth2 API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google OAuth2 API v2 Samples for .NET  

## API Description

Obtains end-user authorization grants for use with other Google APIs.

[Offical Documentation](https://developers.google.com/accounts/docs/OAuth2)

## Sample Description

These samples show how to access the [Google OAuth2 API v2](https://developers.google.com/accounts/docs/OAuth2) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.oauth2.v2](https://www.nuget.org/packages/Google.Apis.oauth2.v2)
Install Command: PM>  Install-Package Google.Apis.oauth2.v2

```
PM> Install-Package Google.Apis.oauth2.v2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.oauth2.v2.oauth2Service.Scope.oauth2Readonly };
var service = GoogleSamplecSharpSample.oauth2v2.Auth.Oauth2Example.Getoauth2Service(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.oauth2v2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.oauth2.v2.oauth2Service.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.oauth2v2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
