![Groups Migration API](https://www.google.com/images/icons/product/discussions-32.gif)

# Unoffical Groups Migration API v1 Samples for .NET  

## API Description

Groups Migration Api.

[Offical Documentation](https://developers.google.com/google-apps/groups-migration/)

## Sample Description

These samples show how to access the [Groups Migration API v1](https://developers.google.com/google-apps/groups-migration/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.GroupsMigration.v1](https://www.nuget.org/packages/Google.Apis.GroupsMigration.v1)
Install Command: PM>  Install-Package Google.Apis.GroupsMigration.v1

```
PM> Install-Package Google.Apis.GroupsMigration.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.GroupsMigration.v1.GroupsMigrationService.Scope.GroupsMigrationReadonly };
var service = GoogleSamplecSharpSample.GroupsMigrationv1.Auth.Oauth2Example.GetGroupsMigrationService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.GroupsMigrationv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.GroupsMigration.v1.GroupsMigrationService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.GroupsMigrationv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
