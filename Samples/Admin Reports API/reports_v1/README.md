![Admin Reports API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Admin Reports API reports_v1 Samples for .NET  

## API Description

Fetches reports for the administrators of G Suite customers about the usage, collaboration, security, and risk for their users.

[Offical Documentation](https://developers.google.com/admin-sdk/reports/)

## Sample Description

These samples show how to access the [Admin Reports API reports_v1](https://developers.google.com/admin-sdk/reports/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.reports.reports_v1](https://www.nuget.org/packages/Google.Apis.reports.reports_v1)
Install Command: PM>  Install-Package Google.Apis.reports.reports_v1

```
PM> Install-Package Google.Apis.reports.reports_v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.reports.reports_v1.reportsService.Scope.reportsReadonly };
var service = GoogleSamplecSharpSample.reportsreports_v1.Auth.Oauth2Example.GetreportsService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.reportsreports_v1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.reports.reports_v1.reportsService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.reportsreports_v1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
