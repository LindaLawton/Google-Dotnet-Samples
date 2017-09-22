![Google Cloud Deployment Manager API](https://www.gstatic.com/images/branding/product/1x/googleg_32dp.png)

# Unoffical Google Cloud Deployment Manager API v2 Samples for .NET  

## API Description

Declares, configures, and deploys complex solutions on Google Cloud Platform.

[Offical Documentation](https://cloud.google.com/deployment-manager/)

## Sample Description

These samples show how to access the [Google Cloud Deployment Manager API v2](https://cloud.google.com/deployment-manager/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.DeploymentManager.v2](https://www.nuget.org/packages/Google.Apis.DeploymentManager.v2)
Install Command: PM>  Install-Package Google.Apis.DeploymentManager.v2

```
PM> Install-Package Google.Apis.DeploymentManager.v2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.DeploymentManager.v2.DeploymentManagerService.Scope.DeploymentManagerReadonly };
var service = GoogleSamplecSharpSample.DeploymentManagerv2.Auth.Oauth2Example.GetDeploymentManagerService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.DeploymentManagerv2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.DeploymentManager.v2.DeploymentManagerService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.DeploymentManagerv2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
