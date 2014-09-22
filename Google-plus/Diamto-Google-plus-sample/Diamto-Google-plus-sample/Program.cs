using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Plus.v1;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Plus.v1.Data;
using System.Collections.Generic;
using System.Linq;

//Project type must be at least .net 4.0
//Nuget
//PM> Install-Package Google.Apis.Plus.v1 


namespace Diamto_Google_plus_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Scopes for use with Google+ API
            // activating Google+ API in console
            // Documentation:  https://developers.google.com/+/api/oauth
            string[] scopes = new string[] {
               // PlusService.Scope.PlusMe,  The https://www.googleapis.com/auth/plus.me scope is not recommended as a login scope because, for users who have not upgraded to Google+, it does not return the user's name or email address.
                PlusService.Scope.PlusLogin,
                PlusService.Scope.UserinfoEmail,
                PlusService.Scope.UserinfoProfile};

            string _client_id = "1046123799103-7mk8g2iok1dv9fphok8v2kv82hiqb0q6.apps.googleusercontent.com";
            string _client_secret = "GeE-cD7PtraV0LqyoxqPnOpv";



            PlusService service = null;
            UserCredential credential = null;

            try
            {
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = _client_id, ClientSecret = _client_secret },
                                                                                     scopes,
                                                                                     Environment.UserName,
                                                                                     CancellationToken.None,
                                                                                     new FileDataStore("Daimto.GooglePlus.Auth.Store")).Result;

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

            // Now we create a Google service. All of our requests will be run though this.
            service = new PlusService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Plus Sample",
            });



            // Getting a list of ALL a users public activities.
            IList<Activity> _Activities = DaimtoGooglePlusHelper.GetAllActivities(service, "me");

            foreach (Activity item in _Activities) {

                Console.WriteLine(item.Actor.DisplayName + " Plus 1s: " + item.Object.Plusoners.TotalItems + " comments: " + item.Object.Replies.TotalItems);            
            }


            //Just getting an activity that has some comments for the example below.
            Activity withComment = _Activities.Where(x => x.Object.Replies.TotalItems > 0).FirstOrDefault();
            // Getting a list of all the comments for an activity
            IList<Comment> _comments = DaimtoGooglePlusHelper.GetAllComments(service, withComment.Id);
            foreach (Comment item in _comments)
            {

                Console.WriteLine("Comment " + item.Actor.DisplayName + " Plus 1s: " + item.Plusoners.TotalItems );
            }

            //Listing of all the people the user has circled.
            IList<Person> people = DaimtoGooglePlusHelper.GetAllPeople(service, "me");


            Console.ReadLine();
          
        }
    }
}
