![PageSpeed Insights API](https://www.google.com/images/icons/product/pagespeed-32.png)

# Unoffical PageSpeed Insights API v2 Samples for .NET  

## API Description

Analyzes the performance of a web page and provides tailored suggestions to make that page faster.

[Offical Documentation](https://developers.google.com/speed/docs/insights/v2/getting-started)

## Sample Description

These samples show how to access the [PageSpeed Insights API v2](https://developers.google.com/speed/docs/insights/v2/getting-started) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.pagespeedonline.v2](https://www.nuget.org/packages/Google.Apis.pagespeedonline.v2)
Install Command: PM>  Install-Package Google.Apis.pagespeedonline.v2

```
PM> Install-Package Google.Apis.pagespeedonline.v2
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.pagespeedonline.v2.pagespeedonlineService.Scope.pagespeedonlineReadonly };
var service = GoogleSamplecSharpSample.pagespeedonlinev2.Auth.Oauth2Example.GetpagespeedonlineService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.pagespeedonlinev2.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.pagespeedonline.v2.pagespeedonlineService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.pagespeedonlinev2.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
