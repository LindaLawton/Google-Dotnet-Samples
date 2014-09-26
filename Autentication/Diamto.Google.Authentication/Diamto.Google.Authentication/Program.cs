using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using System.IO;
using Google.Apis.Plus.v1;
using Google.Apis.Services;
using Google.Apis.Plus.v1.Data;

namespace Diamto.Authentication
{
    class Program
    {
        static void Main(string[] args)
        {
            // authentication 
            // nuget install-package Google.Apis
            // install-package Google.Apis.Auth

            string[] scopes = new string[] {
               // PlusService.Scope.PlusMe,  The https://www.googleapis.com/auth/plus.me scope is not recommended as a login scope because, for users who have not upgraded to Google+, it does not return the user's name or email address.
                PlusService.Scope.PlusLogin,
                PlusService.Scope.UserinfoEmail,
                PlusService.Scope.UserinfoProfile};

            string _client_id = "1046123799103-7mk8g2iok1dv9fphok8v2kv82hiqb0q6.apps.googleusercontent.com";
            string _client_secret = "GeE-cD7PtraV0LqyoxqPnOpv";

            

         
            UserCredential credential = null;
            

            try
            {
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = _client_id, ClientSecret = _client_secret },
                                                                                     scopes,
                                                                                     Environment.UserName,
                                                                                     CancellationToken.None,
                                                                                  //   new LocalFileDataStore("Daimto.Auth.Store")).Result;
                                                                                    new DatabaseDataStore(@"LINDAL-PC2013\SQL2012", "LindaTest", "test123", "test", "test")).Result;

            }
            catch (Exception ex)
            {
                //If the user hits cancel you wont get access.
                if (ex.InnerException.Message.IndexOf("access_denied") != -1)
                {
                    Console.WriteLine("User declined access");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Unknown Authentication Error:" + ex.Message);
                    Console.ReadLine();
                    return;
                }
            }
            finally {

                string filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Daimto.Auth.Store\Google.Apis.Auth.OAuth2.Responses.TokenResponse-" + Environment.UserName;

                Console.WriteLine("refreshToken:" + credential.Token.RefreshToken);
                Console.WriteLine("AccessToken:" + credential.Token.AccessToken);

                Console.WriteLine("");
                Console.WriteLine("FileDatastore:" + filename);
                Console.WriteLine("");
               
                using (StreamReader sr = new StreamReader(filename))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }

                // Now we create a Google service. All of our requests will be run though this.
                PlusService service = new PlusService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Plus Sample",
                });

                int i = 1;
                // Getting a list of ALL a users public activities.
                IList<Activity> _Activities = GetAllActivities(service, "me");

                foreach (Activity item in _Activities)
                {

                    Console.WriteLine(item.Actor.DisplayName + " Plus 1s: " + item.Object.Plusoners.TotalItems + " comments: " + item.Object.Replies.TotalItems);
                }
            }

            int o = 1;



        }

        public static IList<Activity> GetAllActivities(PlusService service, string _userId)
        {
            //List all of the activities in the specified collection for the current user.  
            // Documentation: https://developers.google.com/+/api/latest/activities/list
            ActivitiesResource.ListRequest list = service.Activities.List(_userId, ActivitiesResource.ListRequest.CollectionEnum.Public);
            list.MaxResults = 100;
            ActivityFeed activitesFeed = list.Execute();
            IList<Activity> Activites = new List<Activity>();



            //// Loop through until we arrive at an empty page
            while (activitesFeed.Items != null)
            {
                // Adding each item  to the list.
                foreach (Activity item in activitesFeed.Items)
                {
                    Activites.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (activitesFeed.NextPageToken == null)
                {
                    break;
                }

                // Prepare the next page of results
                list.PageToken = activitesFeed.NextPageToken;

                // Execute and process the next page request
                activitesFeed = list.Execute();

            }

            return Activites;
        }
    }


}
