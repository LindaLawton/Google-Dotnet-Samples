![Stackdriver Trace API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Stackdriver Trace API v1 Samples for .NET  

## API Description

Send and retrieve trace data from Stackdriver Trace. Data is generated and available by default for all App Engine applications. Data from other applications can be written to Stackdriver Trace for display, reporting, and analysis.

[Offical Documentation](https://cloud.google.com/trace)

## Sample Description

These samples show how to access the [Stackdriver Trace API v1](https://cloud.google.com/trace) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.CloudTrace.v1](https://www.nuget.org/packages/Google.Apis.CloudTrace.v1)
Install Command: PM>  Install-Package Google.Apis.CloudTrace.v1

```
PM> Install-Package Google.Apis.CloudTrace.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.CloudTrace.v1.CloudTraceService.Scope.CloudTraceReadonly };
var service = GoogleSamplecSharpSample.CloudTracev1.Auth.Oauth2Example.GetCloudTraceService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.CloudTracev1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.CloudTrace.v1.CloudTraceService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.CloudTracev1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
