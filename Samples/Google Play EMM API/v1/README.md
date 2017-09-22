![Google Play EMM API](https://www.google.com/images/icons/product/android-32.png)

# Unoffical Google Play EMM API v1 Samples for .NET  

## API Description

Manages the deployment of apps to Android for Work users.

[Offical Documentation](https://developers.google.com/android/work/play/emm-api)

## Sample Description

These samples show how to access the [Google Play EMM API v1](https://developers.google.com/android/work/play/emm-api) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.AndroidEnterprise.v1](https://www.nuget.org/packages/Google.Apis.AndroidEnterprise.v1)
Install Command: PM>  Install-Package Google.Apis.AndroidEnterprise.v1

```
PM> Install-Package Google.Apis.AndroidEnterprise.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.AndroidEnterprise.v1.AndroidEnterpriseService.Scope.AndroidEnterpriseReadonly };
var service = GoogleSamplecSharpSample.AndroidEnterprisev1.Auth.Oauth2Example.GetAndroidEnterpriseService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.AndroidEnterprisev1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.AndroidEnterprise.v1.AndroidEnterpriseService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.AndroidEnterprisev1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
