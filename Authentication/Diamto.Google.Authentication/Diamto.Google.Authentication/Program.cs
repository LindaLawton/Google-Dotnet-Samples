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
            PlusService service;

            // Authenticate Oauth2
            String CLIENT_ID = "2046123799103-d0vpdthl4ms0soutcrpe036ckqn7rfpn.apps.googleusercontent.com";
            String CLIENT_SECRET = "NDmluNfTgUk6wgmy7cFo64RV";


            //This is a pure Oauth2 Example
            //service = Authentication.Authenticaton.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "test");


            // Basic example for use with DatabaseDataStore
            //var dbDatastore = new DatabaseDataStore(@"LINDAL\SQL2012", "LindaTest", "test123", "test", "test");
            //service = Authentication.Authenticaton.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "test", dbDatastore);


            //Storeing the file in a diffrent directory the %appData%
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Daimto.Auth.Store\Google.Apis.Auth.OAuth2.Responses.TokenResponse-" + Environment.UserName;

            var localfileDatastore = new LocalFileDataStore(filename);
            service = Authentication.Authenticaton.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "test", localfileDatastore);

            // Getting a list of ALL a users public activities.
            IList<Activity> _Activities = GetAllActivities(service, "me");

            foreach (Activity item in _Activities)
            {

                Console.WriteLine(item.Actor.DisplayName + " Plus 1s: " + item.Object.Plusoners.TotalItems + " comments: " + item.Object.Replies.TotalItems);
            }         



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
