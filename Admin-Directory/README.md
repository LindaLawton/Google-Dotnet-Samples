Diamto Google Directory API  .Net Samples
=================================

Sample project for working with the Google Directory API with .net.

1. Oauth2 Example
2. service acccount example


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
   3. Client ID for Web application: 
      * Client id, Client Secrete will be used in the code.  Make sure to set Redirect URI corectly.  
   4. Enable the Admin SDK
3. Nuget Package: <a href="https://www.nuget.org/packages/Google.Apis.Admin.Directory.directory_v1/">Google.Apis.Admin.Directory.directory_v1</a>
    1. PM> Install-Package Google.Apis.Admin.Directory.directory_v1


Note:  Projects where created in visual studio 10.  
Note2: The client id and secret in the project are test ones and wont work for you.


Tutorials
=================================

Tutorials for these projects can be found on [WWW.DAIMTO.COM](http://www.daimto.com/)


* None yet



Links 
=================================


* [Google .Net client Library](https://code.google.com/p/google-api-dotnet-client/)
* [Using OAuth 2.0 to Access Google APIs](https://developers.google.com/accounts/docs/OAuth2)
* [Stack Over Flow Google-oauth](http://stackoverflow.com/questions/tagged/google-oauth)
* [Stack Over Flow Google-admin-sdk](https://stackoverflow.com/questions/tagged/google-admin-sdk)
* [Directory API Home](https://developers.google.com/admin-sdk/directory/)
* [Nuget package](https://www.nuget.org/packages/Google.Apis.Admin.Directory.directory_v1/)

