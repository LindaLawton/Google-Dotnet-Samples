![Android Management API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Android Management API v1 Samples for .NET  

## API Description

The Android Management API provides remote enterprise management of Android devices and apps.

[Offical Documentation](https://developers.google.com/android/management)

## Sample Description

These samples show how to access the [Android Management API v1](https://developers.google.com/android/management) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.AndroidManagement.v1](https://www.nuget.org/packages/Google.Apis.AndroidManagement.v1)
Install Command: PM>  Install-Package Google.Apis.AndroidManagement.v1

```
PM> Install-Package Google.Apis.AndroidManagement.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.AndroidManagement.v1.AndroidManagementService.Scope.AndroidManagementReadonly };
var service = GoogleSamplecSharpSample.AndroidManagementv1.Auth.Oauth2Example.GetAndroidManagementService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.AndroidManagementv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.AndroidManagement.v1.AndroidManagementService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.AndroidManagementv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
