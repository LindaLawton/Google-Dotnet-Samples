![Stackdriver Monitoring API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Stackdriver Monitoring API v3 Samples for .NET  

## API Description

Manages your Stackdriver Monitoring data and configurations. Most projects must be associated with a Stackdriver account, with a few exceptions as noted on the individual method pages.

[Offical Documentation](https://cloud.google.com/monitoring/api/)

## Sample Description

These samples show how to access the [Stackdriver Monitoring API v3](https://cloud.google.com/monitoring/api/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.Monitoring.v3](https://www.nuget.org/packages/Google.Apis.Monitoring.v3)
Install Command: PM>  Install-Package Google.Apis.Monitoring.v3

```
PM> Install-Package Google.Apis.Monitoring.v3
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.Monitoring.v3.MonitoringService.Scope.MonitoringReadonly };
var service = GoogleSamplecSharpSample.Monitoringv3.Auth.Oauth2Example.GetMonitoringService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.Monitoringv3.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.Monitoring.v3.MonitoringService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.Monitoringv3.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
