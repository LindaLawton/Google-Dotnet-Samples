![Google Cloud Deployment Manager API V2Beta Methods](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google Cloud Deployment Manager API V2Beta Methods v2beta Samples for .NET  

## API Description

The Deployment Manager API allows users to declaratively configure, deploy and run complex solutions on the Google Cloud Platform.

[Offical Documentation](https://developers.google.com/deployment-manager/)

## Sample Description

These samples show how to access the [Google Cloud Deployment Manager API V2Beta Methods v2beta](https://developers.google.com/deployment-manager/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.DeploymentManagerV2Beta.v2beta](https://www.nuget.org/packages/Google.Apis.DeploymentManagerV2Beta.v2beta)
Install Command: PM>  Install-Package Google.Apis.DeploymentManagerV2Beta.v2beta

```
PM> Install-Package Google.Apis.DeploymentManagerV2Beta.v2beta
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.DeploymentManagerV2Beta.v2beta.DeploymentManagerV2BetaService.Scope.DeploymentManagerV2BetaReadonly };
var service = GoogleSamplecSharpSample.DeploymentManagerV2Betav2beta.Auth.Oauth2Example.GetDeploymentManagerV2BetaService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.DeploymentManagerV2Betav2beta.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.DeploymentManagerV2Beta.v2beta.DeploymentManagerV2BetaService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.DeploymentManagerV2Betav2beta.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
