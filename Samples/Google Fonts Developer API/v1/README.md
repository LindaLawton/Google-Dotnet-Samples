![Google Fonts Developer API](https://www.google.com/images/icons/feature/font_api-32.gif)

# Unoffical Google Fonts Developer API v1 Samples for .NET  

## API Description

Accesses the metadata for all families served by Google Fonts, providing a list of families currently available (including available styles and a list of supported script subsets).

[Offical Documentation](https://developers.google.com/fonts/docs/developer_api)

## Sample Description

These samples show how to access the [Google Fonts Developer API v1](https://developers.google.com/fonts/docs/developer_api) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.webfonts.v1](https://www.nuget.org/packages/Google.Apis.webfonts.v1)
Install Command: PM>  Install-Package Google.Apis.webfonts.v1

```
PM> Install-Package Google.Apis.webfonts.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.webfonts.v1.webfontsService.Scope.webfontsReadonly };
var service = GoogleSamplecSharpSample.webfontsv1.Auth.Oauth2Example.GetwebfontsService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.webfontsv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.webfonts.v1.webfontsService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.webfontsv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
