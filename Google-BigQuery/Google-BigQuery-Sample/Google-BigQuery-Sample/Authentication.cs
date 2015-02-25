using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Bigquery.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using System.IO;
using System.Security.Cryptography.X509Certificates;


namespace Google_BigQuery_Sample
{
  public  class Authentication
    {

        /// <summary>
        /// Authenticate to Google Using Oauth2
        /// Documentation https://developers.google.com/accounts/docs/OAuth2
        /// </summary>
        /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
        /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
        /// <param name="userName">A string used to identify a user.</param>
        /// <returns></returns>
        public static BigqueryService  AuthenticateOauth(string clientId, string clientSecret, string userName)
        {

            string[] scopes = new string[] { BigqueryService.Scope.Bigquery,                // view and manage your BigQuery data
                                             BigqueryService.Scope.BigqueryInsertdata ,     // Insert Data into Big query
                                             BigqueryService.Scope.CloudPlatform,           // view and manage your data acroos cloud platform services
                                             BigqueryService.Scope.DevstorageFullControl,   // manage your data on Cloud platform services
                                             BigqueryService.Scope.DevstorageReadOnly ,     // view your data on cloud platform servies
                                             BigqueryService.Scope.DevstorageReadWrite };   // manage your data on cloud platform servies

            try
            {
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                             , scopes
                                                                                             , userName
                                                                                             , CancellationToken.None
                                                                                             , new FileDataStore("Daimto.BigQuery.Auth.Store")).Result;

                BigqueryService service = new BigqueryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "BigQuery API Sample",
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
        public static BigqueryService AuthenticateServiceAccount(string serviceAccountEmail, string keyFilePath)
        {

            // check the file exists
            if (!File.Exists(keyFilePath))
            {
                Console.WriteLine("An Error occurred - Key file does not exist");
                return null;
            }

            string[] scopes = new string[] { BigqueryService.Scope.Bigquery,                // view and manage your BigQuery data
                                             BigqueryService.Scope.BigqueryInsertdata ,     // Insert Data into Big query
                                             BigqueryService.Scope.CloudPlatform,           // view and manage your data acroos cloud platform services
                                             BigqueryService.Scope.DevstorageFullControl,   // manage your data on Cloud platform services
                                             BigqueryService.Scope.DevstorageReadOnly ,     // view your data on cloud platform servies
                                             BigqueryService.Scope.DevstorageReadWrite };   // manage your data on cloud platform servies
       

            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            try
            {
                ServiceAccountCredential credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(serviceAccountEmail)
                    {
                        Scopes = scopes
                    }.FromCertificate(certificate));

                // Create the service.
                BigqueryService service = new BigqueryService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "BigQuery API Sample",
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
