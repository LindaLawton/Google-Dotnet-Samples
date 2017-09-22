![AdSense Host API](https://www.google.com/images/icons/product/adsense-32.png)

# Unoffical AdSense Host API v4.1 Samples for .NET  

## API Description

Generates performance reports, generates ad codes, and provides publisher management capabilities for AdSense Hosts.

[Offical Documentation](https://developers.google.com/adsense/host/)

## Sample Description

These samples show how to access the [AdSense Host API v4.1](https://developers.google.com/adsense/host/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.AdSenseHost.v4.1](https://www.nuget.org/packages/Google.Apis.AdSenseHost.v4.1)
Install Command: PM>  Install-Package Google.Apis.AdSenseHost.v4.1

```
PM> Install-Package Google.Apis.AdSenseHost.v4.1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.AdSenseHost.v4.1.AdSenseHostService.Scope.AdSenseHostReadonly };
var service = GoogleSamplecSharpSample.AdSenseHostv4.1.Auth.Oauth2Example.GetAdSenseHostService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.AdSenseHostv4.1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.AdSenseHost.v4.1.AdSenseHostService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.AdSenseHostv4.1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
