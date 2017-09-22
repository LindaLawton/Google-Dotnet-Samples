![YouTube Data API](https://www.google.com/images/icons/product/youtube-32.png)

# Unoffical YouTube Data API v3 Samples for .NET  

## API Description

Supports core YouTube features, such as uploading videos, creating and managing playlists, searching for content, and much more.

[Offical Documentation](https://developers.google.com/youtube/v3)

## Sample Description

These samples show how to access the [YouTube Data API v3](https://developers.google.com/youtube/v3) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.YouTube.v3](https://www.nuget.org/packages/Google.Apis.YouTube.v3)
Install Command: PM>  Install-Package Google.Apis.YouTube.v3

```
PM> Install-Package Google.Apis.YouTube.v3
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.YouTube.v3.YouTubeService.Scope.YouTubeReadonly };
var service = GoogleSamplecSharpSample.YouTubev3.Auth.Oauth2Example.GetYouTubeService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.YouTubev3.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.YouTube.v3.YouTubeService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.YouTubev3.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
