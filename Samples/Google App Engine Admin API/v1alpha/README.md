![Google App Engine Admin API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google App Engine Admin API v1alpha Samples for .NET  

## API Description

The App Engine Admin API enables developers to provision and manage their App Engine applications.

[Offical Documentation](https://cloud.google.com/appengine/docs/admin-api/)

## Sample Description

These samples show how to access the [Google App Engine Admin API v1alpha](https://cloud.google.com/appengine/docs/admin-api/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.appengine.v1alpha](https://www.nuget.org/packages/Google.Apis.appengine.v1alpha)
Install Command: PM>  Install-Package Google.Apis.appengine.v1alpha

```
PM> Install-Package Google.Apis.appengine.v1alpha
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.appengine.v1alpha.appengineService.Scope.appengineReadonly };
var service = GoogleSamplecSharpSample.appenginev1alpha.Auth.Oauth2Example.GetappengineService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.appenginev1alpha.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.appengine.v1alpha.appengineService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.appenginev1alpha.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
