![Google Sheets API](http://www.google.com/images/icons/product/search-32.gif)

# Unoffical Google Sheets API v4 Samples for .NET  

## API Description

Reads and writes Google Sheets.

[Offical Documentation](https://developers.google.com/sheets/)

## Sample Description

These samples show how to access the [Google Sheets API v4](https://developers.google.com/sheets/) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.Sheets.v4](https://www.nuget.org/packages/Google.Apis.Sheets.v4)
Install Command: PM>  Install-Package Google.Apis.Sheets.v4

```
PM> Install-Package Google.Apis.Sheets.v4
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.Sheets.v4.SheetsService.Scope.SheetsReadonly };
var service = GoogleSamplecSharpSample.Sheetsv4.Auth.Oauth2Example.GetSheetsService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.Sheetsv4.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.Sheets.v4.SheetsService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.Sheetsv4.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
