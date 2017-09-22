![Compute Engine API](https://www.google.com/images/icons/product/compute_engine-32.png)

# Unoffical Compute Engine API beta Samples for .NET  

## API Description

Creates and runs virtual machines on Google Cloud Platform.

[Offical Documentation](https://developers.google.com/compute/docs/reference/latest/)

## Sample Description

These samples show how to access the [Compute Engine API beta](https://developers.google.com/compute/docs/reference/latest/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.compute.beta](https://www.nuget.org/packages/Google.Apis.compute.beta)
Install Command: PM>  Install-Package Google.Apis.compute.beta

```
PM> Install-Package Google.Apis.compute.beta
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.compute.beta.computeService.Scope.computeReadonly };
var service = GoogleSamplecSharpSample.computebeta.Auth.Oauth2Example.GetcomputeService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.computebeta.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.compute.beta.computeService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.computebeta.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
