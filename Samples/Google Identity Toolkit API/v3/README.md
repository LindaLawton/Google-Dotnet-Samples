![Google Identity Toolkit API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google Identity Toolkit API v3 Samples for .NET  

## API Description

Help the third party sites to implement federated login.

[Offical Documentation](https://developers.google.com/identity-toolkit/v3/)

## Sample Description

These samples show how to access the [Google Identity Toolkit API v3](https://developers.google.com/identity-toolkit/v3/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.IdentityToolkit.v3](https://www.nuget.org/packages/Google.Apis.IdentityToolkit.v3)
Install Command: PM>  Install-Package Google.Apis.IdentityToolkit.v3

```
PM> Install-Package Google.Apis.IdentityToolkit.v3
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.IdentityToolkit.v3.IdentityToolkitService.Scope.IdentityToolkitReadonly };
var service = GoogleSamplecSharpSample.IdentityToolkitv3.Auth.Oauth2Example.GetIdentityToolkitService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.IdentityToolkitv3.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.IdentityToolkit.v3.IdentityToolkitService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.IdentityToolkitv3.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
