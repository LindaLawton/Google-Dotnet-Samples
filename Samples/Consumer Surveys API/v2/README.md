![Consumer Surveys API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Consumer Surveys API v2 Samples for .NET  

## API Description

Creates and conducts surveys, lists the surveys that an authenticated user owns, and retrieves survey results and information about specified surveys.

[Offical Documentation](https://www.google.com/search?q=Consumer+Surveys)

## Sample Description

These samples show how to access the [Consumer Surveys API v2](https://www.google.com/search?q=Consumer+Surveys) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.ConsumerSurveys.v2](https://www.nuget.org/packages/Google.Apis.ConsumerSurveys.v2)
Install Command: PM>  Install-Package Google.Apis.ConsumerSurveys.v2

```
PM> Install-Package Google.Apis.ConsumerSurveys.v2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.ConsumerSurveys.v2.ConsumerSurveysService.Scope.ConsumerSurveysReadonly };
var service = GoogleSamplecSharpSample.ConsumerSurveysv2.Auth.Oauth2Example.GetConsumerSurveysService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.ConsumerSurveysv2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.ConsumerSurveys.v2.ConsumerSurveysService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.ConsumerSurveysv2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
