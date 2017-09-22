![Drive API](https://ssl.gstatic.com/docs/doclist/images/drive_icon_32.png)

# Unoffical Drive API v2 Samples for .NET  

## API Description

Manages files in Drive including uploading, downloading, searching, detecting changes, and updating sharing permissions.

[Offical Documentation](https://developers.google.com/drive/)

## Sample Description

These samples show how to access the [Drive API v2](https://developers.google.com/drive/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.drive.v2](https://www.nuget.org/packages/Google.Apis.drive.v2)
Install Command: PM>  Install-Package Google.Apis.drive.v2

```
PM> Install-Package Google.Apis.drive.v2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.drive.v2.driveService.Scope.driveReadonly };
var service = GoogleSamplecSharpSample.drivev2.Auth.Oauth2Example.GetdriveService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.drivev2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.drive.v2.driveService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.drivev2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
