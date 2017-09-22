![Google Mirror API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google Mirror API v1 Samples for .NET  

## API Description

Interacts with Glass users via the timeline.

[Offical Documentation](https://developers.google.com/glass)

## Sample Description

These samples show how to access the [Google Mirror API v1](https://developers.google.com/glass) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.mirror.v1](https://www.nuget.org/packages/Google.Apis.mirror.v1)
Install Command: PM>  Install-Package Google.Apis.mirror.v1

```
PM> Install-Package Google.Apis.mirror.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.mirror.v1.mirrorService.Scope.mirrorReadonly };
var service = GoogleSamplecSharpSample.mirrorv1.Auth.Oauth2Example.GetmirrorService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.mirrorv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.mirror.v1.mirrorService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.mirrorv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
