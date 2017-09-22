![Google Spectrum Database API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google Spectrum Database API v1explorer Samples for .NET  

## API Description

API for spectrum-management functions.

[Offical Documentation](http://developers.google.com/spectrum)

## Sample Description

These samples show how to access the [Google Spectrum Database API v1explorer](http://developers.google.com/spectrum) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.spectrum.v1explorer](https://www.nuget.org/packages/Google.Apis.spectrum.v1explorer)
Install Command: PM>  Install-Package Google.Apis.spectrum.v1explorer

```
PM> Install-Package Google.Apis.spectrum.v1explorer
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.spectrum.v1explorer.spectrumService.Scope.spectrumReadonly };
var service = GoogleSamplecSharpSample.spectrumv1explorer.Auth.Oauth2Example.GetspectrumService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.spectrumv1explorer.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.spectrum.v1explorer.spectrumService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.spectrumv1explorer.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
