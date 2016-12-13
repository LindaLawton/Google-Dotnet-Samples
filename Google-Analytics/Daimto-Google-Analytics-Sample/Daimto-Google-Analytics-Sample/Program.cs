using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;

//Target framework 4.0
//Nuget package http://www.nuget.org/packages/Google.Apis.Analytics.v3
//pm> Install-Package Google.Apis.Analytics.v3 

namespace Daimto.Google.Sample.Analytics
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalyticsService service;


            // Authenticate Oauth2
            string CLIENT_ID = "YOUR_CLIENT_ID";
            string CLIENT_SECRET = "YOUR_CLIENT_SECRET";
            service = DaimtoAnalyticsAuthenticationHelper.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "test");

            //// Service account Authentication 
            //string SERVICE_ACCOUNT_EMAIL = "YOUR_SERVICE_ACCOUNT_EMAIL";
            //string SERVICE_ACCOUNT_KEYFILE = @"YOUR_SERVICE_ACCOUNT_KEYFILE";
            //service = DaimtoAnalyticsAuthenticationHelper.AuthenticateServiceAccount(SERVICE_ACCOUNT_EMAIL, SERVICE_ACCOUNT_KEYFILE);




            //Get account summary and display them.
            foreach (AccountSummary account in DaimtoAnaltyicsManagmentHelper.AccountSummaryList(service).Items)
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
            foreach (Account account in DaimtoAnaltyicsManagmentHelper.AccountList(service))
            {

                // Account
                Console.WriteLine(string.Format("Account: {0}({1})", account.Name, account.Id));
                foreach (Webproperty wp in DaimtoAnaltyicsManagmentHelper.WebpropertyList(service, account.Id))
                {
                    // Web Properties within that account
                    Console.WriteLine(string.Format("\tWeb Property: {0}({1})", wp.Name, wp.Id ));

                    foreach (Profile profile in DaimtoAnaltyicsManagmentHelper.ProfileList(service, account.Id, wp.Id))
                    {

                        Console.WriteLine(string.Format("\t\tProfile: {0}({1})",profile.Name,profile.Id));
                    }
                }
            }

           
            //Getting a list of the Dimensions and metrics.

            string lastGroup = string.Empty;
            string lastType = string.Empty;
            Columns metadata = DaimtoAnaltyicsMetaDataHelper.MetaDataList(service);
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
            
            DaimtoAnaltyicsReportingHelper.OptionalValues options = new DaimtoAnaltyicsReportingHelper.OptionalValues();
            options.Dimensions = "ga:date";
            //Make sure the profile id you send is valid.  
            var x = DaimtoAnaltyicsReportingHelper.Get(service, "YOUR_VIEW_ID", "10daysAgo", "today", "ga:sessions", options);


            DaimtoAnaltyicsRealTimeHelper.OptionalValues rtOptions = new DaimtoAnaltyicsRealTimeHelper.OptionalValues();
            options.Dimensions = "rt:userType";
            //Make sure the profile id you send is valid.  
            var realTimeData = DaimtoAnaltyicsRealTimeHelper.Get(service, "YOUR_VIEW_ID", "rt:activeUsers", rtOptions);

            foreach (var headers in realTimeData.ColumnHeaders) {

             Console.WriteLine( String.Format("{0} - {1} - {2}", headers.Name ,  headers.ColumnType ,headers.DataType));
            
            
            }
           
            foreach (List<string> row in realTimeData.Rows) {

                foreach (string col in row) {
                    Console.Write(col + " ");  // writes the value of the column
                }
                Console.Write("\r\n");
                
            }


            Console.ReadLine();
        }

       
    }
}
