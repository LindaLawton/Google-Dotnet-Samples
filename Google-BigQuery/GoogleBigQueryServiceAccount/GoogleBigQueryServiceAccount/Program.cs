using System;
using Google.Apis.Auth.OAuth2;
using System.Security.Cryptography.X509Certificates;
//using Google.Apis.Bigquery.v2;
using Google.Apis.Services;
using Google.Apis.Drive.v2;
using Google.Apis.Plus.v1;

//Install-Package Google.Apis.Bigquery.v2
namespace GoogleBigQueryServiceAccount
{
    class Program
    {
        //private static String ACTIVITY_ID = "AIzaSyCSgCx4G8qEymGl5TcZLAXFueVsfhl2cTA";
        static void Main(string[] args)
        {

            Console.WriteLine("BigQuery API - Service Account");
            Console.WriteLine("==========================");

            PlusService.Scope.UserinfoEmail

            //String serviceAccountEmail = "539621478854-imkdv94bgujcom228h3ea33kmkoefhil@developer.gserviceaccount.com";

            //var certificate = new X509Certificate2(@"C:\Users\linda_l\Documents\GitHub\GoogleBigQueryServiceAccount\GoogleBigQueryServiceAccount\key.p12", "notasecret", X509KeyStorageFlags.Exportable);

            //ServiceAccountCredential credential = new ServiceAccountCredential(
            //   new ServiceAccountCredential.Initializer(serviceAccountEmail)
            //   {
            //       Scopes = new[] { BigqueryService.Scope.DevstorageReadOnly }
            //   }.FromCertificate(certificate));

            //// Create the service.
            //var service = new BigqueryService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = "BigQuery API Sample",
            //});



             Console.WriteLine("BigQuery API - Service Account");
            Console.WriteLine("==========================");

            var serviceAccountEmail = "539621478854-imkdv94bgujcom228h3ea33kmkoefhil@developer.gserviceaccount.com";

            ServiceAccountCredential certificate = new X509Certificate2(@"C:\Users\linda_l\Documents\GitHub\GoogleBigQueryServiceAccount\GoogleBigQueryServiceAccount\key.p12", "notasecret", X509KeyStorageFlags.Exportable);

            
             credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = new[] { DriveService.Scope.DriveReadonly }
               }.FromCertificate(certificate));

            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample",
            });


//            directory service
//                X509Certificate2 certificate = new X509Certificate2(key_path,
//                         "notasecret", X509KeyStorageFlags.Exportable);

//ServiceAccountCredential credential = new ServiceAccountCredential(
//           new ServiceAccountCredential.Initializer("publickey.gserviceaccount.com")
//           {   Scopes = scopes,
//               User = "admin@domain.com"
//           }.FromCertificate(certificate));

//var service = new DirectoryService(new BaseClientService.Initializer()
//        {
//            HttpClientInitializer = credential,
//            ApplicationName = "appname",
//        });

//service.Users.List().Domain = "cavintek.com";
//Users results = service.Users.List().Execute();

        }
    }
}
