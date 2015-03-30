using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.YouTube.v3;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;

namespace Daimto_YouTube_Data
{
   public class Authentication
    {

        /// <summary>
        /// Authenticate to Google Using Oauth2
        /// Documentation https://developers.google.com/accounts/docs/OAuth2
        /// </summary>
        /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
        /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
        /// <param name="userName">A string used to identify a user.</param>
        /// <returns></returns>
        public static YouTubeService AuthenticateOauth(string clientId, string clientSecret, string userName)
        {
            
            string[] scopes = new string[] { YouTubeService.Scope.Youtube,  // view and manage your YouTube account
                                             YouTubeService.Scope.YoutubeForceSsl,
                                             YouTubeService.Scope.Youtubepartner,
                                             YouTubeService.Scope.YoutubepartnerChannelAudit,
                                             YouTubeService.Scope.YoutubeReadonly,
                                             YouTubeService.Scope.YoutubeUpload}; 

            try
            {
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                             , scopes
                                                                                             , userName
                                                                                             , CancellationToken.None
                                                                                             , new FileDataStore("Daimto.YouTube.Auth.Store")).Result;

                YouTubeService service = new YouTubeService(new YouTubeService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "YouTube Data API Sample",
                });
                return service;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;

            }

        }

        



    }

    }

