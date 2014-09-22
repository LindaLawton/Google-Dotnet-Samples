using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using AE.Net.Mail;
using Google.Apis.Plus.v1;
using Google.Apis.Services;
// Install-Package AE.Net.Mail 
// Install-Package Google.Apis.auth 
// Install-Package Google.Apis.Plus.v1 
namespace Google.mail.DotNet
{
    class GAAutentication
    {
        public PlusService service;
        public  UserCredential credential;

        public static GAAutentication Autenticate(string _client_id, string _client_secret)
        {
            GAAutentication result = new GAAutentication();
           
            try
            {
               UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = _client_id, ClientSecret = _client_secret },
                                                                         new[] {"https://mail.google.com/ email" },
                                                                         "Lindau",
                                                                         CancellationToken.None,
                                                                         new FileDataStore("Analytics.Auth.Store")).Result;
            }
            catch (Exception ex)
            {

                int i = 1;
            }

            if (result.credential != null)
            {

                result.service = new PlusService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = result.credential,
                    ApplicationName = "Google mail",
                });

        
                Google.Apis.Plus.v1.Data.Person me = result.service.People.Get("me").Execute();

                Google.Apis.Plus.v1.Data.Person.EmailsData myAccountEmail =  me.Emails.Where(a => a.Type == "account").FirstOrDefault();

                // Connect to the IMAP server. The 'true' parameter specifies to use SSL
                // which is important (for Gmail at least)
                ImapClient ic = new ImapClient("imap.gmail.com", myAccountEmail.Value, result.credential.Token.AccessToken,
                                ImapClient.AuthMethods.SaslOAuth, 993, true);
                // Select a mailbox. Case-insensitive
                ic.SelectMailbox("INBOX");
                Console.WriteLine(ic.GetMessageCount());
                // Get the first *11* messages. 0 is the first message;
                // and it also includes the 10th message, which is really the eleventh ;)
                // MailMessage represents, well, a message in your mailbox
                MailMessage[] mm = ic.GetMessages(0, 10);
                foreach (MailMessage m in mm)
                {
                    Console.WriteLine(m.Subject + " " + m.Date.ToString());
                }
                // Probably wiser to use a using statement
                ic.Dispose();
            }
            return result;

        }



        //public void initServiceAccount(string keyPath, string accountEmailAddress)
        //{
        //    var certificate = new X509Certificate2(keyPath, "notasecret", X509KeyStorageFlags.Exportable);

        //    var credentials = new ServiceAccountCredential(
        //       new ServiceAccountCredential.Initializer(accountEmailAddress)
        //       {
        //           Scopes = new[] { AnalyticsService.Scope.AnalyticsReadonly }
        //       }.FromCertificate(certificate));

        //    service = new AnalyticsService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credentials,
        //        ApplicationName = "WorthlessVariable"
        //    });


        //}

    }
}