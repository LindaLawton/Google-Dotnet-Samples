![Google Container Engine API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Container Engine API v1beta1 Samples for .NET  

## API Description

The Google Container Engine API is used for building and managing container based applications, powered by the open source Kubernetes technology.

[Offical Documentation](https://cloud.google.com/container-engine/)

## Sample Description

These samples show how to access the [Google Container Engine API v1beta1](https://cloud.google.com/container-engine/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.Container.v1beta1](https://www.nuget.org/packages/Google.Apis.Container.v1beta1)
Install Command: PM>  Install-Package Google.Apis.Container.v1beta1

```
PM> Install-Package Google.Apis.Container.v1beta1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.Container.v1beta1.ContainerService.Scope.ContainerReadonly };
var service = GoogleSamplecSharpSample.Containerv1beta1.Auth.Oauth2Example.GetContainerService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.Containerv1beta1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.Container.v1beta1.ContainerService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.Containerv1beta1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
