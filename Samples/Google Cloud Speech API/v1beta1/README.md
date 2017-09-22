![Google Cloud Speech API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Cloud Speech API v1beta1 Samples for .NET  

## API Description

Converts audio to text by applying powerful neural network models.

[Offical Documentation](https://cloud.google.com/speech/)

## Sample Description

These samples show how to access the [Google Cloud Speech API v1beta1](https://cloud.google.com/speech/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.Speech.v1beta1](https://www.nuget.org/packages/Google.Apis.Speech.v1beta1)
Install Command: PM>  Install-Package Google.Apis.Speech.v1beta1

```
PM> Install-Package Google.Apis.Speech.v1beta1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.Speech.v1beta1.SpeechService.Scope.SpeechReadonly };
var service = GoogleSamplecSharpSample.Speechv1beta1.Auth.Oauth2Example.GetSpeechService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.Speechv1beta1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.Speech.v1beta1.SpeechService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.Speechv1beta1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
