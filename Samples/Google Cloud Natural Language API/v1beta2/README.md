![Google Cloud Natural Language API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Cloud Natural Language API v1beta2 Samples for .NET  

## API Description

Provides natural language understanding technologies to developers. Examples include sentiment analysis, entity recognition, entity sentiment analysis, and text annotations.

[Offical Documentation](https://cloud.google.com/natural-language/)

## Sample Description

These samples show how to access the [Google Cloud Natural Language API v1beta2](https://cloud.google.com/natural-language/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.CloudNaturalLanguage.v1beta2](https://www.nuget.org/packages/Google.Apis.CloudNaturalLanguage.v1beta2)
Install Command: PM>  Install-Package Google.Apis.CloudNaturalLanguage.v1beta2

```
PM> Install-Package Google.Apis.CloudNaturalLanguage.v1beta2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.CloudNaturalLanguage.v1beta2.CloudNaturalLanguageService.Scope.CloudNaturalLanguageReadonly };
var service = GoogleSamplecSharpSample.CloudNaturalLanguagev1beta2.Auth.Oauth2Example.GetCloudNaturalLanguageService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.CloudNaturalLanguagev1beta2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.CloudNaturalLanguage.v1beta2.CloudNaturalLanguageService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.CloudNaturalLanguagev1beta2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
