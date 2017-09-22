![Google Cloud Runtime Configuration API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Cloud Runtime Configuration API v1 Samples for .NET  

## API Description

The Runtime Configurator allows you to dynamically configure and expose variables through Google Cloud Platform. In addition, you can also set Watchers and Waiters that will watch for changes to your data and return based on certain conditions.

[Offical Documentation](https://cloud.google.com/deployment-manager/runtime-configurator/)

## Sample Description

These samples show how to access the [Google Cloud Runtime Configuration API v1](https://cloud.google.com/deployment-manager/runtime-configurator/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.CloudRuntimeConfig.v1](https://www.nuget.org/packages/Google.Apis.CloudRuntimeConfig.v1)
Install Command: PM>  Install-Package Google.Apis.CloudRuntimeConfig.v1

```
PM> Install-Package Google.Apis.CloudRuntimeConfig.v1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.CloudRuntimeConfig.v1.CloudRuntimeConfigService.Scope.CloudRuntimeConfigReadonly };
var service = GoogleSamplecSharpSample.CloudRuntimeConfigv1.Auth.Oauth2Example.GetCloudRuntimeConfigService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.CloudRuntimeConfigv1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.CloudRuntimeConfig.v1.CloudRuntimeConfigService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.CloudRuntimeConfigv1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
