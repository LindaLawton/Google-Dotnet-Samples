![DCM/DFA Reporting And Trafficking API](https://www.google.com/images/icons/product/doubleclick-32.gif)

# Unoffical DCM/DFA Reporting And Trafficking API v2.8 Samples for .NET  

## API Description

Manages your DoubleClick Campaign Manager ad campaigns and reports.

[Offical Documentation](https://developers.google.com/doubleclick-advertisers/)

## Sample Description

These samples show how to access the [DCM/DFA Reporting And Trafficking API v2.8](https://developers.google.com/doubleclick-advertisers/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.dfareporting.v2.8](https://www.nuget.org/packages/Google.Apis.dfareporting.v2.8)
Install Command: PM>  Install-Package Google.Apis.dfareporting.v2.8

```
PM> Install-Package Google.Apis.dfareporting.v2.8
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.dfareporting.v2.8.dfareportingService.Scope.dfareportingReadonly };
var service = GoogleSamplecSharpSample.dfareportingv2.8.Auth.Oauth2Example.GetdfareportingService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.dfareportingv2.8.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.dfareporting.v2.8.dfareportingService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.dfareportingv2.8.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
