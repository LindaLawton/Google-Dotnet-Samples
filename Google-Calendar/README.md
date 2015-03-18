
![alt tag](http://www.daimto.com/wp-content/uploads/2014/12/calendar-logo.png)

﻿Diamto Google Calendar .Net Samples
=================================

Sample project for working with the Google Calendar API with .net

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
3. Nuget Package: <a href="https://www.nuget.org/packages/Google.Apis.Calendar.v3/">Google.Apis.Calendar.v3</a>
    1. PM> Install-Package Google.Apis.Calendar.v3


Note:  Projects where created in visual studio 10.  
Note2: The client id and secrete in the project are test ones and wont work for you.

Tutorials
=================================

Tutorials for these projects can be found on [WWW.DAIMTO.COM](http://www.daimto.com/)

 1. [Google Calendar API Authentication with C#](http://www.daimto.com/google-calendar-api-authentication-with-c/)


Links
===========================================
* [Google Calendar api Refrence](https://developers.google.com/google-apps/calendar/v3/reference/)
* [Google Dot net client Library](https://code.google.com/p/google-api-dotnet-client/)
* [Using OAuth 2.0 to Access Google APIs](https://developers.google.com/accounts/docs/OAuth2)
* [StackOverflow Google Calendar](httphttp://stackoverflow.com/questions/tagged/google-calendar)
