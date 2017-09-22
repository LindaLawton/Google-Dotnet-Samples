![Firebase Rules API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Firebase Rules API v1 Samples for .NET  

## API Description

Creates and manages rules that determine when a Firebase Rules-enabled service should permit a request.

[Offical Documentation](https://firebase.google.com/docs/storage/security)

## Sample Description

These samples show how to access the [Firebase Rules API v1](https://firebase.google.com/docs/storage/security) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.FirebaseRules.v1](https://www.nuget.org/packages/Google.Apis.FirebaseRules.v1)
Install Command: PM>  Install-Package Google.Apis.FirebaseRules.v1

```
PM> Install-Package Google.Apis.FirebaseRules.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.FirebaseRules.v1.FirebaseRulesService.Scope.FirebaseRulesReadonly };
var service = GoogleSamplecSharpSample.FirebaseRulesv1.Auth.Oauth2Example.GetFirebaseRulesService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.FirebaseRulesv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.FirebaseRules.v1.FirebaseRulesService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.FirebaseRulesv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
