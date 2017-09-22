![Blogger API](https://www.google.com/images/icons/product/blogger-32.png)

# Unoffical Blogger API v3 Samples for .NET  

## API Description

API for access to the data within Blogger.

[Offical Documentation](https://developers.google.com/blogger/docs/3.0/getting_started)

## Sample Description

These samples show how to access the [Blogger API v3](https://developers.google.com/blogger/docs/3.0/getting_started) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.blogger.v3](https://www.nuget.org/packages/Google.Apis.blogger.v3)
Install Command: PM>  Install-Package Google.Apis.blogger.v3

```
PM> Install-Package Google.Apis.blogger.v3
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.blogger.v3.bloggerService.Scope.bloggerReadonly };
var service = GoogleSamplecSharpSample.bloggerv3.Auth.Oauth2Example.GetbloggerService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.bloggerv3.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.blogger.v3.bloggerService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.bloggerv3.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
