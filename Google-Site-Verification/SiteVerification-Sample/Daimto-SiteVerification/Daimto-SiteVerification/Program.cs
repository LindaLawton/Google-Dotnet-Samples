using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.SiteVerification.v1;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;

//Nuget Install-Package Google.Apis.SiteVerification.v1
namespace Daimto_SiteVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            // Authenticate Oauth2
            String CLIENT_ID = "1046123799103-7mk8g2iok1dv9fphok8v2kv82hiqb0q6.apps.googleusercontent.com";
            String CLIENT_SECRET = "GeE-cD7PtraV0LqyoxqPnOpv";


            string[] scopes = new string[] { SiteVerificationService.Scope.Siteverification };
            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                                           {
                                            ClientId = CLIENT_ID,
                                            ClientSecret = CLIENT_SECRET
                                             },
                   scopes,
                     Environment.UserName,
                                                                CancellationToken.None,
                                                            new FileDataStore("Daimto.SiteVerification.Auth.Store")
                                                                ).Result;

            // Create the service.
            var service = new SiteVerificationService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "SiteVerification API Sample",
            });

           var x =   service.WebResource.List().Execute();

           int i = 1;


        }
    }
}
