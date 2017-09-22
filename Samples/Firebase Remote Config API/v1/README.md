![Firebase Remote Config API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Firebase Remote Config API v1 Samples for .NET  

## API Description

Firebase Remote Config API allows the 3P clients to manage Remote Config conditions and parameters for Firebase applications.

[Offical Documentation](https://firebase.google.com/docs/remote-config/)

## Sample Description

These samples show how to access the [Firebase Remote Config API v1](https://firebase.google.com/docs/remote-config/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.FirebaseRemoteConfig.v1](https://www.nuget.org/packages/Google.Apis.FirebaseRemoteConfig.v1)
Install Command: PM>  Install-Package Google.Apis.FirebaseRemoteConfig.v1

```
PM> Install-Package Google.Apis.FirebaseRemoteConfig.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.FirebaseRemoteConfig.v1.FirebaseRemoteConfigService.Scope.FirebaseRemoteConfigReadonly };
var service = GoogleSamplecSharpSample.FirebaseRemoteConfigv1.Auth.Oauth2Example.GetFirebaseRemoteConfigService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.FirebaseRemoteConfigv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.FirebaseRemoteConfig.v1.FirebaseRemoteConfigService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.FirebaseRemoteConfigv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
