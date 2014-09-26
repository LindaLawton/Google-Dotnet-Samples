using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Analytics.v3;
using Google.Apis.Services;
using Google.Apis.Analytics.v3.Data;

//Target framework 4.0
//Nuget package http://www.nuget.org/packages/Google.Apis.Analytics.v3
//pm> Install-Package Google.Apis.Analytics.v3 

namespace Daimto_Google_Analytics_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalyticsService Service;


            // Authenticate Oauth2
            String CLIENT_ID = "1046123799103-7mk8g2iok1dv9fphok8v2kv82hiqb0q6.apps.googleusercontent.com";
            String CLIENT_SECRET = "GeE-cD7PtraV0LqyoxqPnOpv";
            Service = DaimtoAnalyticsAuthenticationHelper.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "test");

            //// Service account Authentication 
            //String SERVICE_ACCOUNT_EMAIL = "1046123799103-nk421gjc2v8mlr2qnmmqaak04ntb1dbp@developer.gserviceaccount.com";
            //string SERVICE_ACCOUNT_KEYFILE = @"c:\Diamto Test Everything Project-5381f306d5a1.p12";
            //Service = DaimtoAnalyticsAuthenticationHelper.AuthenticateServiceAccount(SERVICE_ACCOUNT_EMAIL, SERVICE_ACCOUNT_KEYFILE);




            //Get account summary and display them.
            foreach (AccountSummary account in DaimtoAnaltyicsManagmentHelper.AccountSummaryList(Service))
            {
                // Account
                Console.WriteLine("Account: " + account.Name + "(" + account.Id + ")");

                foreach (WebPropertySummary wp in account.WebProperties)
                {

                    // Web Properties within that account
                    Console.WriteLine("\tWeb Property: " + wp.Name + "(" + wp.Id + ")");

                    //Don't forget to check its not null. Believe it or not it could be.  
                    if (wp.Profiles != null)
                    {

                        foreach (ProfileSummary profile in wp.Profiles)
                        {
                            // Profiles with in that web property.
                            Console.WriteLine("\t\tProfile: " + profile.Name + "(" + profile.Id + ")");
                        }
                    }
                }
            }
         

            //This will also display a list to the user, you will get more information in an Account,
            // Web property, and profile objects then you do from the same summary objects
            //This will require a large number of requests to be sent against the API, be mindful of 
            //  your quota (10000 requests per profile(view) per day) if you use this method.   
            foreach (Account account in DaimtoAnaltyicsManagmentHelper.AccountList(Service))
            {

                // Account
                Console.WriteLine("Account: " + account.Name + "(" + account.Id + ")");
                foreach (Webproperty wp in DaimtoAnaltyicsManagmentHelper.WebpropertyList(Service, account.Id))
                {
                    // Web Properties within that account
                    Console.WriteLine("\tWeb Property: " + wp.Name + "(" + wp.Id + ")");

                    foreach (Profile profile in DaimtoAnaltyicsManagmentHelper.ProfileList(Service, account.Id, wp.Id))
                    {

                        Console.WriteLine("\t\tProfile: " + profile.Name + "(" + profile.Id + ")");
                    }
                }
            }

           
            //Getting a list of the Dimensions and metrics.

            string lastGroup = string.Empty;
            string lastType = string.Empty;
            Columns metadata = DaimtoAnaltyicsMetaDataHelper.MetaDataList(Service);
            foreach (Column column in metadata.Items.OrderBy(a => a.Attributes["group"]).OrderBy(a => a.Attributes["type"]).ToList())
            {
                if (column.Attributes["group"] != lastGroup)
                {
                    Console.WriteLine("Group: " + column.Attributes["group"]);
                    lastGroup = column.Attributes["group"];
                    lastType = string.Empty;
                }
                if (column.Attributes["type"] != lastType)
                {
                    Console.WriteLine("\t" + column.Attributes["type"]);
                    lastType = column.Attributes["type"];
                }

                Console.WriteLine("\t\t" + column.Attributes["uiName"] + " : " + column.Id);
            }
            
            DaimtoAnaltyicsReportingHelper.optionalValues options = new DaimtoAnaltyicsReportingHelper.optionalValues();
            options.Dimensions = "ga:date";
            //Make sure the profile id you send is valid.  
            var x = DaimtoAnaltyicsReportingHelper.get(Service, "78110423", "10daysAgo", "today", "ga:sessions", options);




        }
    }
}
