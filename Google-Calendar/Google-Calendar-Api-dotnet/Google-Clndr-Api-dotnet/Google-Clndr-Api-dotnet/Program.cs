using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;


//Nuget package https://www.nuget.org/packages/Google.Apis.Calendar.v3/
//PM> Install-Package Google.Apis.Calendar.v3


namespace Google_Clndr_Api_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            CalendarService service; 
            //// Service account Authentication 
            // IF you take the service account Email address you can give it access to any calendar you want just like you would a user.

            String SERVICE_ACCOUNT_EMAIL = "2046123799103-6v9cj8jbub068jgmss54m9gkuk4q2qu8@developer.gserviceaccount.com";
            string SERVICE_ACCOUNT_KEYFILE = @"C:\Users\HP_User\Downloads\Diamto Test Everything Project-ec242f46b936.p12";
            service = Authentication.AuthenticateServiceAccount(SERVICE_ACCOUNT_EMAIL, SERVICE_ACCOUNT_KEYFILE);
           

            // Authenticate Oauth2
            //String CLIENT_ID = "2046123799103-d0vpdthl4ms0soutcrpe036ckqn7rfpn.apps.googleusercontent.com";
            //String CLIENT_SECRET = "NDmluNfTgUk6wgmy7cFo64RV";
            //service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "test");

           var x =  DaimtoCalendarListHelper.list(service, null);

            int i = 1;


        }
    }
}
