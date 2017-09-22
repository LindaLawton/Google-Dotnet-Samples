![Calendar API](http://www.google.com/images/icons/product/calendar-32.png)

# Unoffical Calendar API v3 Samples for .NET  

## API Description

Manipulates events and other calendar data.

[Offical Documentation](https://developers.google.com/google-apps/calendar/firstapp)

## Sample Description

These samples show how to access the [Calendar API v3](https://developers.google.com/google-apps/calendar/firstapp) with the Offical [Google .Net client library](https://github.com/google/google-api-dotnet-client)

Tutorials to go along with some of these samples can be found on [www.daimto.com](http://www.daimto.com/)

## Developer Documentation

* [Google API client Library for .NET - Get Started](https://developers.google.com/api-client-library/dotnet/get_started)

* [Supported APIs](https://developers.google.com/api-client-library/dotnet/apis/)

### Installation

NuGet package:

Location: [NuGet Google.Apis.calendar.v3](https://www.nuget.org/packages/Google.Apis.calendar.v3)
Install Command: PM>  Install-Package Google.Apis.calendar.v3

```
PM> Install-Package Google.Apis.calendar.v3
```

### Usage

OAuth2
```
var keyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
var scopes = new String[] { Google.Apis.calendar.v3.calendarService.Scope.calendarReadonly };
var service = GoogleSamplecSharpSample.calendarv3.Auth.Oauth2Example.GetcalendarService(keyFileLocation, user, scopes);
```

Public API Key

```
var apiKey = "XXXX";
var servicePublicKey = GoogleSamplecSharpSample.calendarv3.Auth.ApiKeyExample.GetService(apiKey);
```

Service Account
```
var serviceAccountKeyFileLocation = @"C:\Users\Daimto\Documents\DaimtoTestEverythingCredentials\Diamto Test Everything Project-29e50502c19b.json";
var serviceAccountEmail = "googledrivemirrornas@daimto-tutorials-101.iam.gserviceaccount.com";
var scopes = new String[] { Google.Apis.calendar.v3.calendarService.Scope.Calendar };            
var serviceAccountService = GoogleSamplecSharpSample.calendarv3.Auth.ServiceAccountExample.AuthenticateServiceAccount(serviceAccountKeyFileLocation, serviceAccountEmail, scopes);
```
