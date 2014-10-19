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

            string[] scopes = new string[] {
        CalendarService.Scope.Calendar  ,  // Manage your calendars
        CalendarService.Scope.CalendarReadonly    // View your Calendars
            };

            // Authenticate Oauth2
            String CLIENT_ID = "1046123799103-7mk8g2iok1dv9fphok8v2kv82hiqb0q6.apps.googleusercontent.com";
            String CLIENT_SECRET = "GeE-cD7PtraV0LqyoxqPnOpv";
            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = CLIENT_ID, ClientSecret = CLIENT_SECRET }
                                                                , scopes
                                                                , Environment.UserName
                                                                , CancellationToken.None
                                                                , new FileDataStore("Daimto.GoogleCalendar.Auth.Store")).Result;



            CalendarService service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Calendar API Sample",
            });

            DaimtoCalendarListHelper.list(service, null);

            int i = 1;


        }
    }
}
