![Google Identity and Access Management (IAM) API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Identity and Access Management (IAM) API v1 Samples for .NET  

## API Description

Manages identity and access control for Google Cloud Platform resources, including the creation of service accounts, which you can use to authenticate to Google and make API calls.

[Offical Documentation](https://cloud.google.com/iam/)

## Sample Description

These samples show how to access the [Google Identity and Access Management (IAM) API v1](https://cloud.google.com/iam/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.iam.v1](https://www.nuget.org/packages/Google.Apis.iam.v1)
Install Command: PM>  Install-Package Google.Apis.iam.v1

```
PM> Install-Package Google.Apis.iam.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.iam.v1.iamService.Scope.iamReadonly };
var service = GoogleSamplecSharpSample.iamv1.Auth.Oauth2Example.GetiamService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.iamv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.iam.v1.iamService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.iamv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
