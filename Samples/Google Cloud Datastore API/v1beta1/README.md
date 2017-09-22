![Google Cloud Datastore API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Cloud Datastore API v1beta1 Samples for .NET  

## API Description

Accesses the schemaless NoSQL database to provide fully managed, robust, scalable storage for your application.

[Offical Documentation](https://cloud.google.com/datastore/)

## Sample Description

These samples show how to access the [Google Cloud Datastore API v1beta1](https://cloud.google.com/datastore/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.datastore.v1beta1](https://www.nuget.org/packages/Google.Apis.datastore.v1beta1)
Install Command: PM>  Install-Package Google.Apis.datastore.v1beta1

```
PM> Install-Package Google.Apis.datastore.v1beta1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.datastore.v1beta1.datastoreService.Scope.datastoreReadonly };
var service = GoogleSamplecSharpSample.datastorev1beta1.Auth.Oauth2Example.GetdatastoreService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.datastorev1beta1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.datastore.v1beta1.datastoreService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.datastorev1beta1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
