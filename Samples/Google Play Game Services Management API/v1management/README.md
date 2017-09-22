![Google Play Game Services Management API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google Play Game Services Management API v1management Samples for .NET  

## API Description

The Management API for Google Play Game Services.

[Offical Documentation](https://developers.google.com/games/services)

## Sample Description

These samples show how to access the [Google Play Game Services Management API v1management](https://developers.google.com/games/services) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.GamesManagement.v1management](https://www.nuget.org/packages/Google.Apis.GamesManagement.v1management)
Install Command: PM>  Install-Package Google.Apis.GamesManagement.v1management

```
PM> Install-Package Google.Apis.GamesManagement.v1management
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.GamesManagement.v1management.GamesManagementService.Scope.GamesManagementReadonly };
var service = GoogleSamplecSharpSample.GamesManagementv1management.Auth.Oauth2Example.GetGamesManagementService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.GamesManagementv1management.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.GamesManagement.v1management.GamesManagementService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.GamesManagementv1management.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
