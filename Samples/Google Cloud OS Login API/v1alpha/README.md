![Google Cloud OS Login API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Cloud OS Login API v1alpha Samples for .NET  

## API Description

Manages OS login configuration for Directory API users.

[Offical Documentation](https://cloud.google.com/compute/docs/oslogin/rest/)

## Sample Description

These samples show how to access the [Google Cloud OS Login API v1alpha](https://cloud.google.com/compute/docs/oslogin/rest/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.CloudOSLogin.v1alpha](https://www.nuget.org/packages/Google.Apis.CloudOSLogin.v1alpha)
Install Command: PM>  Install-Package Google.Apis.CloudOSLogin.v1alpha

```
PM> Install-Package Google.Apis.CloudOSLogin.v1alpha
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.CloudOSLogin.v1alpha.CloudOSLoginService.Scope.CloudOSLoginReadonly };
var service = GoogleSamplecSharpSample.CloudOSLoginv1alpha.Auth.Oauth2Example.GetCloudOSLoginService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.CloudOSLoginv1alpha.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.CloudOSLogin.v1alpha.CloudOSLoginService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.CloudOSLoginv1alpha.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
