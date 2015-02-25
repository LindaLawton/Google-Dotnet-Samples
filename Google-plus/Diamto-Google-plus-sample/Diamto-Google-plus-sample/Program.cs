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
                PlusService.Scope.PlusLogin,
                PlusService.Scope.UserinfoEmail,
                PlusService.Scope.UserinfoProfile ,"profile" };

            string _client_id = "1046123799103-d0vpdthl4ms0soutcrpe036ckqn7rfpn.apps.googleusercontent.com";
            string _client_secret = "NDmluNfTgUk6wgmy7cFo64RV";
       // https://accounts.google.com/o/oauth2/auth?access_type=offline&response_type=code&client_id=1046123799103-d0vpdthl4ms0soutcrpe036ckqn7rfpn.apps.googleusercontent.com&redirect_uri=http://localhost:15918/authorize/&scope=https://www.googleapis.com/auth/plus.login%20https://www.googleapis.com/auth/userinfo.email%20https://www.googleapis.com/auth/userinfo.profile&data-requestvisibleactions=http://schema.org/AddAction
            PlusService service = null;
            UserCredential credential = null;
            try
            {
               
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = _client_id, ClientSecret = _client_secret },
                                                                                     scopes, 
                                                                                     Environment.UserName,
                                                                                     CancellationToken.None,
                                                                                     new FileDataStore("Daimto.GooglePlusm.Auth.Store")).Result;
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

          
            Moment body = new Moment();
            body.Type = "http://schema.org/AddAction";           
           
            ItemScope itemScope = new ItemScope();
            itemScope.Id = "target-id-1" ;
            itemScope.Type = "http://schema.org/AddAction";
            itemScope.Name = "The Google+ Platform";
            itemScope.Description = "A page that describes just how awesome Google+ is!";
            itemScope.Image = "https://developers.google.com/+/plugins/snippet/examples/thing.png";
            body.Object = itemScope;

            try
            {
                var l = service.Moments.Insert(body, "me", MomentsResource.InsertRequest.CollectionEnum.Vault);
                l.Execute();
            }
            catch (Exception ex)
            {
                int i = 1;


            }
            // Getting a list of ALL a users public activities.
            IList<Activity> _Activities = DaimtoGooglePlusHelper.GetAllActivities(service, "me");

            foreach (Activity item in _Activities)
            {

                Console.WriteLine(item.Actor.DisplayName + " Plus 1s: " + item.Object.Plusoners.TotalItems + " comments: " + item.Object.Replies.TotalItems);
            }


            //Just getting an activity that has some comments for the example below.
            Activity withComment = _Activities.Where(x => x.Object.Replies.TotalItems > 0).FirstOrDefault();
            // Getting a list of all the comments for an activity
            IList<Comment> _comments = DaimtoGooglePlusHelper.GetAllComments(service, withComment.Id);
            foreach (Comment item in _comments)
            {

                Console.WriteLine("Comment " + item.Actor.DisplayName + " Plus 1s: " + item.Plusoners.TotalItems);
            }

            //Listing of all the people the user has circled.
            IList<Person> people = DaimtoGooglePlusHelper.GetAllPeople(service, "me");


            Console.ReadLine();

        }
    }
}
