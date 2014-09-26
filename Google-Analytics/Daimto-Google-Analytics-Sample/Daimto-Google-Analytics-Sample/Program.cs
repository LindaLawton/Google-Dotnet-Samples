using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Analytics.v3;
using Google.Apis.Services;

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


            // DaimtoAnaltyicsManagmentHelper.WebpropertyGet(Service, "1", "UA-45053573-1");

            //DaimtoAnaltyicsManagmentHelper.WebpropertyInsert(Service, "45053573", "Test", "http:\\www.daimto.com");
            //DaimtoAnaltyicsMetaDataHelper.GetDimensions(Service);

            DaimtoAnaltyicsReportingHelper.optionalValues options = new DaimtoAnaltyicsReportingHelper.optionalValues();

            options.Dimensions = "ga:date";

            var x = DaimtoAnaltyicsReportingHelper.get(Service, "78110423", "10daysAgo", "today", "ga:sessions", options);




        }
    }
}
