using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Services;
using System.IO;
using System.Security.Cryptography.X509Certificates;


namespace AdminSdkSample
{
    class AuthenticationHelper
    {

        /// <summary>
        /// Authenticate to Google Using Oauth2
        /// Documentation https://developers.google.com/accounts/docs/OAuth2
        /// </summary>
        /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
        /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
        /// <param name="userName">A string used to identify a user.</param>
        /// <returns></returns>
        public static DirectoryService AuthenticateOauth(string clientId, string clientSecret, string userName)
        {

            // There are a lot of scopes check here: https://developers.google.com/admin-sdk/directory/v1/guides/authorizing
            string[] scopes = new string[] {
                    DirectoryService.Scope.AdminDirectoryGroup  ,  // Manage your Groups
                    DirectoryService.Scope.AdminDirectoryUser   // Manage users 
                    };

            try
            {
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                    , scopes
                                                                    , userName
                                                                    , CancellationToken.None
                                                                    , new FileDataStore("Daimto.AdminSDK.Auth.Store")).Result;



                DirectoryService service = new DirectoryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Directory API Sample",
                });
                return service;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;

            }

        }

        /// <summary>
        /// Authenticating to Google using a Service account
        /// Documentation: https://developers.google.com/accounts/docs/OAuth2#serviceaccount
        /// </summary>
        /// <param name="serviceAccountEmail">From Google Developer console https://console.developers.google.com</param>
        /// <param name="keyFilePath">Location of the Service account key file downloaded from Google Developer console https://console.developers.google.com</param>
        /// <returns></returns>
        public static DirectoryService AuthenticateServiceAccount(string serviceAccountEmail, string keyFilePath)
        {

            // check the file exists
            if (!File.Exists(keyFilePath))
            {
                Console.WriteLine("An Error occurred - Key file does not exist");
                return null;
            }

            // There are a lot of scopes check here: https://developers.google.com/admin-sdk/directory/v1/guides/authorizing
            string[] scopes = new string[] {
                    DirectoryService.Scope.AdminDirectoryGroup  ,  // Manage your Groups
                    DirectoryService.Scope.AdminDirectoryUser   // Manage users 
                    };

            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            try
            {
                ServiceAccountCredential credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(serviceAccountEmail)
                    {
                        Scopes = scopes
                    }.FromCertificate(certificate));

                // Create the service.
                DirectoryService service = new DirectoryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Directory API Sample",
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
