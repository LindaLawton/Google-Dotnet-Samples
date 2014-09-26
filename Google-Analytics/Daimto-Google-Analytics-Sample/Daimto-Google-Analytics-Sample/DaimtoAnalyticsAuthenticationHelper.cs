using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Daimto_Google_Analytics_Sample
{
    public class DaimtoAnalyticsAuthenticationHelper
    {

        /// <summary>
        /// Authenticate to Google Using Oauth2
        /// Documentation https://developers.google.com/accounts/docs/OAuth2
        /// </summary>
        /// <param name="_clientId">From Google Developer console https://console.developers.google.com</param>
        /// <param name="_clientSecret">From Google Developer console https://console.developers.google.com</param>
        /// <param name="_UserName">A string used to identify a user.</param>
        /// <returns></returns>
        public static AnalyticsService AuthenticateOauth(string _clientId, string _clientSecret, string _UserName)
        {
            
            string[] scopes = new string[] { AnalyticsService.Scope.Analytics,  // view and manage your analytics data
                                             AnalyticsService.Scope.AnalyticsEdit,  // edit management actives
                                             AnalyticsService.Scope.AnalyticsManageUsers,   // manage users
                                             AnalyticsService.Scope.AnalyticsReadonly};     // View analytics data

            try
            {
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = _clientId, ClientSecret = _clientSecret }
                                                                                             , scopes
                                                                                             , _UserName
                                                                                             , CancellationToken.None
                                                                                             , new FileDataStore("Daimto.GoogleAnalytics.Auth.Store")).Result;

                AnalyticsService service = new AnalyticsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Analytics API Sample",
                });
                return service;
            }
            catch (Exception ex)
            {

                Console.WriteLine("An Error occurred - " + ex.InnerException);
                return null;

            }

        }

        /// <summary>
        /// Autenticating to Google using a Service account
        /// Documentation: https://developers.google.com/accounts/docs/OAuth2#serviceaccount
        /// </summary>
        /// <param name="_serviceAccountEmail">From Google Developer console https://console.developers.google.com</param>
        /// <param name="_KeyFilePath">Location of the Service account key file downloaded from Google Developer console https://console.developers.google.com</param>
        /// <returns></returns>
        public static AnalyticsService AuthenticateServiceAccount(string _serviceAccountEmail, string _KeyFilePath)
        {

            // check the file exists
            if (!File.Exists(_KeyFilePath))
            {
                Console.WriteLine("An Error occurred - Key file does not exist");
                return null;    
            }

            string[] scopes = new string[] { AnalyticsService.Scope.Analytics,  // view and manage your analytics data
                                             AnalyticsService.Scope.AnalyticsEdit,  // edit management actives
                                             AnalyticsService.Scope.AnalyticsManageUsers,   // manage users
                                             AnalyticsService.Scope.AnalyticsReadonly};     // View analytics data            
            
            var certificate = new X509Certificate2(_KeyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            try
            {
                ServiceAccountCredential credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(_serviceAccountEmail)
                   {
                       Scopes = scopes
                   }.FromCertificate(certificate));

                // Create the service.
                AnalyticsService service = new AnalyticsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Analytics API Sample",
                });
                return service;
            }
            catch (Exception ex)
            {

                Console.WriteLine("An Error occurred - " + ex.InnerException);
                return null;

            }
        }



    }
}
