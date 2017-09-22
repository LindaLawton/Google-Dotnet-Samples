![Stackdriver Logging API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Stackdriver Logging API v2 Samples for .NET  

## API Description

Writes log entries and manages your Stackdriver Logging configuration.

[Offical Documentation](https://cloud.google.com/logging/docs/)

## Sample Description

These samples show how to access the [Stackdriver Logging API v2](https://cloud.google.com/logging/docs/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.Logging.v2](https://www.nuget.org/packages/Google.Apis.Logging.v2)
Install Command: PM>  Install-Package Google.Apis.Logging.v2

```
PM> Install-Package Google.Apis.Logging.v2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.Logging.v2.LoggingService.Scope.LoggingReadonly };
var service = GoogleSamplecSharpSample.Loggingv2.Auth.Oauth2Example.GetLoggingService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.Loggingv2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.Logging.v2.LoggingService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.Loggingv2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
