![Cloud User Accounts API](https://www.google.com/images/icons/product/compute_engine-32.png)

# Unoffical Cloud User Accounts API vm_beta Samples for .NET  

## API Description

Creates and manages users and groups for accessing Google Compute Engine virtual machines.

[Offical Documentation](https://cloud.google.com/compute/docs/access/user-accounts/api/latest/)

## Sample Description

These samples show how to access the [Cloud User Accounts API vm_beta](https://cloud.google.com/compute/docs/access/user-accounts/api/latest/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.CloudUserAccounts.vm_beta](https://www.nuget.org/packages/Google.Apis.CloudUserAccounts.vm_beta)
Install Command: PM>  Install-Package Google.Apis.CloudUserAccounts.vm_beta

```
PM> Install-Package Google.Apis.CloudUserAccounts.vm_beta
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.CloudUserAccounts.vm_beta.CloudUserAccountsService.Scope.CloudUserAccountsReadonly };
var service = GoogleSamplecSharpSample.CloudUserAccountsvm_beta.Auth.Oauth2Example.GetCloudUserAccountsService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.CloudUserAccountsvm_beta.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.CloudUserAccounts.vm_beta.CloudUserAccountsService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.CloudUserAccountsvm_beta.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
