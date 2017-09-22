![Google App Engine Admin API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google App Engine Admin API v1beta4 Samples for .NET  

## API Description

The App Engine Admin API enables developers to provision and manage their App Engine applications.

[Offical Documentation](https://cloud.google.com/appengine/docs/admin-api/)

## Sample Description

These samples show how to access the [Google App Engine Admin API v1beta4](https://cloud.google.com/appengine/docs/admin-api/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.appengine.v1beta4](https://www.nuget.org/packages/Google.Apis.appengine.v1beta4)
Install Command: PM>  Install-Package Google.Apis.appengine.v1beta4

```
PM> Install-Package Google.Apis.appengine.v1beta4
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.appengine.v1beta4.appengineService.Scope.appengineReadonly };
var service = GoogleSamplecSharpSample.appenginev1beta4.Auth.Oauth2Example.GetappengineService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.appenginev1beta4.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.appengine.v1beta4.appengineService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.appenginev1beta4.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
