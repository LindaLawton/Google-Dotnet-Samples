![Prediction API](https://www.google.com/images/icons/feature/predictionapi-32.png)

# Unoffical Prediction API v1.4 Samples for .NET  

## API Description

Lets you access a cloud hosted machine learning service that makes it easy to build smart apps

[Offical Documentation](https://developers.google.com/prediction/docs/developer-guide)

## Sample Description

These samples show how to access the [Prediction API v1.4](https://developers.google.com/prediction/docs/developer-guide) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.prediction.v1.4](https://www.nuget.org/packages/Google.Apis.prediction.v1.4)
Install Command: PM>  Install-Package Google.Apis.prediction.v1.4

```
PM> Install-Package Google.Apis.prediction.v1.4
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.prediction.v1.4.predictionService.Scope.predictionReadonly };
var service = GoogleSamplecSharpSample.predictionv1.4.Auth.Oauth2Example.GetpredictionService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.predictionv1.4.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.prediction.v1.4.predictionService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.predictionv1.4.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
