
![alt tag](https://www.google.com/drive/images/drive/logo-drive.png)

﻿Diamto Google Drive .Net Samples
=================================

Sample project for working with the Google Drive API with .net

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
3. Nuget Package: <a href="https://www.nuget.org/packages/Google.Apis.Drive.v2/">Google.Apis.Drive.v2</a>
    1. PM> Install-Package Google.Apis.Drive.v2


Note:  Projects where created in visual studio 10.  
Note2: The client id and secrete in the project are test ones and wont work for you.

Tutorials
=================================

Tutorials for these projects can be found on [WWW.DAIMTO.COM](http://www.daimto.com/)

Three part tutorial series:

 1. [Google Drive API with C# .net – Files - Files, directories, search](http://www.daimto.com/google-drive-api-c/)
 2. [Google Drive API with C# .net – Upload, update, patch, delete,trash](http://www.daimto.com/google-drive-api-c-upload/)
 3. [Google Drive API with C# .net – Download](http://www.daimto.com/google-drive-api-c-download/)



Links
===========================================
* [Google Drive api Refrence](https://developers.google.com/drive/v2/reference/)
* [Google Dot net client Library](https://code.google.com/p/google-api-dotnet-client/)
* [Using OAuth 2.0 to Access Google APIs](https://developers.google.com/accounts/docs/OAuth2)
* [StackOverflow Google drive sdk](http://stackoverflow.com/questions/tagged/google-drive-sdk)
