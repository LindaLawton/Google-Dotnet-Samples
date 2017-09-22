![Google Play Game Services Publishing API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google Play Game Services Publishing API v1configuration Samples for .NET  

## API Description

The Publishing API for Google Play Game Services.

[Offical Documentation](https://developers.google.com/games/services)

## Sample Description

These samples show how to access the [Google Play Game Services Publishing API v1configuration](https://developers.google.com/games/services) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.GamesConfiguration.v1configuration](https://www.nuget.org/packages/Google.Apis.GamesConfiguration.v1configuration)
Install Command: PM>  Install-Package Google.Apis.GamesConfiguration.v1configuration

```
PM> Install-Package Google.Apis.GamesConfiguration.v1configuration
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.GamesConfiguration.v1configuration.GamesConfigurationService.Scope.GamesConfigurationReadonly };
var service = GoogleSamplecSharpSample.GamesConfigurationv1configuration.Auth.Oauth2Example.GetGamesConfigurationService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.GamesConfigurationv1configuration.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.GamesConfiguration.v1configuration.GamesConfigurationService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.GamesConfigurationv1configuration.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
