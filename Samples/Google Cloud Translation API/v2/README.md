![Google Cloud Translation API](https://www.google.com/images/icons/product/translate-32.png)

# Unoffical Google Cloud Translation API v2 Samples for .NET  

## API Description

The Google Cloud Translation API lets websites and programs integrate with    Google Translate programmatically.

[Offical Documentation](https://code.google.com/apis/language/translate/v2/getting_started.html)

## Sample Description

These samples show how to access the [Google Cloud Translation API v2](https://code.google.com/apis/language/translate/v2/getting_started.html) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.Translate.v2](https://www.nuget.org/packages/Google.Apis.Translate.v2)
Install Command: PM>  Install-Package Google.Apis.Translate.v2

```
PM> Install-Package Google.Apis.Translate.v2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.Translate.v2.TranslateService.Scope.TranslateReadonly };
var service = GoogleSamplecSharpSample.Translatev2.Auth.Oauth2Example.GetTranslateService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.Translatev2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.Translate.v2.TranslateService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.Translatev2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
