![alt tag](http://www.daimto.com/wp-content/uploads/2013/11/google-analytics.png)


﻿Diamto Google Analytics .Net Samples
=================================

Sample project for working with the Google Analytics API with .net


SETUP
=================================

1. Visual Studio Target Framework:
   *  .Net Framework 4.0
   *  .Net Framework 4.5
2. Authentication:  <a href="https://console.developers.google.com/">Google Developer console</a> 
   1. Oauth2:  APIs & auth -> Credentials:  Client ID for native application 
      *  Client id and Client Secret will be used in the code
   2. Service Account:  Service Account  
      *  P12 key file and Email Address will be used in the code.
   3. Client ID for web application: 
      * Client id, Client Secrete will be used in the code.  Make sure to set Redirect URI corectly. 
3. Nuget Package: <a href="https://www.nuget.org/packages/Google.Apis.Analytics.v3/">Google.Apis.Analytics.v3</a>
    1. PM> Install-Package Google.Apis.Analytics.v3
4. Real-time API Beta:  The Real Time Reporting API is currently available as a developer preview in limited beta. If you're 
    interested in  signing up, request access to the beta. Apply for access wait 24 hours and then try you will not hear from      Google when you have been approved.  
    1. [Real-time Api Application](https://docs.google.com/forms/d/1qfRFysCikpgCMGqgF3yXdUyQW4xAlLyjKuOoOEFN2Uw/viewform)
5. Management API write operations Beta:  Write operations in the Management API (e.g. create, update, delete, patch) for Web Property, View (Profile), and Goal resources is currently available as a developer preview in limited beta. If you're interested in using these features, request access to the beta. This can take up to 3 weeks you will get an email if your application has been excepted.
     1.  [Management Api Application](https://docs.google.com/forms/d/1xyjp6ca4YkGjh7TDi1Z3XyA3XHcRHkKzFentxzUrmPY/viewform)


Note:  Projects where created in visual studio 10.  
Note2: The client id and secret in the project are test ones and wont work for you.


Tutorials
=================================

Tutorials for these projects can be found on [WWW.DAIMTO.COM](http://www.daimto.com/)

* [Google Analytics API Introduction](http://www.daimto.com/google-analytics-api-v3-with-c/)
* [Google Analytics API Authentication with C# OAuth2 vs Service Account](http://www.daimto.com/googleAnalytics-authentication-csharp/)
* [Google Analytics Management API with C#Accounts, Web Properties and views(Profiles)](http://www.daimto.com/googleAnalytics-management-csharp/)
* Google Analytics Management API with C# – Advanced
* Google Analytics Management API with C# – Upload
* [Google Analytics Meta-Data API with C# - Showing current dimensions and metrics](http://www.daimto.com/google-analytics-metadata-api/)
* [Google Analytics Real-Time API with C# - Whats happening now!](http://www.daimto.com/googleAnalytics-realtime-csharp/)
* [Google Analytics Core Reporting API with C#  – Its all about the data baby!](http://www.daimto.com/googleAnalytics-core-csharp/)


Links 
=================================

* [Google Analytics Dimensions & Metrics refrence](https://developers.google.com/analytics/devguides/reporting/core/dimsmets)
* [Google Analytics Core Reporting API](https://developers.google.com/analytics/devguides/reporting/core/v3/reference)
* [Google analytics Managment API](https://developers.google.com/analytics/devguides/config/)
* [Google .Net client Library](https://code.google.com/p/google-api-dotnet-client/)
* [Using OAuth 2.0 to Access Google APIs](https://developers.google.com/accounts/docs/OAuth2)
* [Stack Over Flow Google-Analyitcs-API](http://stackoverflow.com/questions/tagged/google-analytics-api)

