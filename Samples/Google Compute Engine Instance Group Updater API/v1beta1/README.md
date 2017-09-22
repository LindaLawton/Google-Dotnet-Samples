![Google Compute Engine Instance Group Updater API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google Compute Engine Instance Group Updater API v1beta1 Samples for .NET  

## API Description

[Deprecated. Please use compute.instanceGroupManagers.update method. replicapoolupdater API will be disabled after December 30th, 2016] Updates groups of Compute Engine instances.

[Offical Documentation](https://cloud.google.com/compute/docs/instance-groups/manager/#applying_rolling_updates_using_the_updater_service)

## Sample Description

These samples show how to access the [Google Compute Engine Instance Group Updater API v1beta1](https://cloud.google.com/compute/docs/instance-groups/manager/#applying_rolling_updates_using_the_updater_service) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.replicapoolupdater.v1beta1](https://www.nuget.org/packages/Google.Apis.replicapoolupdater.v1beta1)
Install Command: PM>  Install-Package Google.Apis.replicapoolupdater.v1beta1

```
PM> Install-Package Google.Apis.replicapoolupdater.v1beta1
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.replicapoolupdater.v1beta1.replicapoolupdaterService.Scope.replicapoolupdaterReadonly };
var service = GoogleSamplecSharpSample.replicapoolupdaterv1beta1.Auth.Oauth2Example.GetreplicapoolupdaterService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.replicapoolupdaterv1beta1.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.replicapoolupdater.v1beta1.replicapoolupdaterService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.replicapoolupdaterv1beta1.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
