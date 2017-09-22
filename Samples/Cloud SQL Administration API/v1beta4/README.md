![Cloud SQL Administration API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Cloud SQL Administration API v1beta4 Samples for .NET  

## API Description

Creates and configures Cloud SQL instances, which provide fully-managed MySQL databases.

[Offical Documentation](https://cloud.google.com/sql/docs/reference/latest)

## Sample Description

These samples show how to access the [Cloud SQL Administration API v1beta4](https://cloud.google.com/sql/docs/reference/latest) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.SQLAdmin.v1beta4](https://www.nuget.org/packages/Google.Apis.SQLAdmin.v1beta4)
Install Command: PM>  Install-Package Google.Apis.SQLAdmin.v1beta4

```
PM> Install-Package Google.Apis.SQLAdmin.v1beta4
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.SQLAdmin.v1beta4.SQLAdminService.Scope.SQLAdminReadonly };
var service = GoogleSamplecSharpSample.SQLAdminv1beta4.Auth.Oauth2Example.GetSQLAdminService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.SQLAdminv1beta4.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.SQLAdmin.v1beta4.SQLAdminService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.SQLAdminv1beta4.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
