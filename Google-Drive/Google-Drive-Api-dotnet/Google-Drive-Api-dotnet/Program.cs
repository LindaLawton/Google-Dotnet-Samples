using System;

using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
using System.Collections.Generic;

namespace Google_Drive_Api_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {

            String CLIENT_ID = "1046123799103-7mk8g2iok1dv9fphok8v2kv82hiqb0q6.apps.googleusercontent.com";
            String CLIENT_SECRET = "GeE-cD7PtraV0LqyoxqPnOpv";

            string[] scopes = new string[] { DriveService.Scope.Drive,
                                             DriveService.Scope.DriveFile};
            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = CLIENT_ID, ClientSecret = CLIENT_SECRET }
                                                                                    , scopes
                                                                                    , Environment.UserName
                                                                                    , CancellationToken.None
                                                                                    , new FileDataStore("Daimto.GoogleDrive.Auth.Store")).Result;
            
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample",
            });


           
            // Things to search on.

            // Listing files with search.  
            // This searches for a directory with the name DiamtoSample
            string Q = "title = 'DiamtoSample' and mimeType = 'application/vnd.google-apps.folder'";
            IList<File> _Files = DaimtoGoogleDriveHelper.GetFiles(service, Q);

            foreach (File item in _Files)
            {
                Console.WriteLine(item.Title + " " + item.MimeType);
            }
            
            // If there isn't a directory with this name lets create one.
            if (_Files.Count == 0)
            {
                _Files.Add(DaimtoGoogleDriveHelper.createDirectory(service, "DiamtoSample", "DiamtoSample", "root"));                              
            }
            
            // We should have a directory now because we either had it to begin with or we just created one.
            if (_Files.Count != 0) {

                 // This is the ID of the directory 
                string directoryId = _Files[0].Id;

               //Upload a file
               File newFile = DaimtoGoogleDriveHelper.uploadFile(service,@"c:\temp\hold.txt",directoryId);
               // Update The file
               File UpdatedFile = DaimtoGoogleDriveHelper.updateFile(service, @"c:\temp\hold.txt", directoryId, newFile.Id);
               // Download the file
               DaimtoGoogleDriveHelper.downloadFile(service, newFile, @"C:\" + newFile.Title);
               // delete The file
               FilesResource.DeleteRequest request = service.Files.Delete(newFile.Id);
               request.Execute();
            }

            // Getting a list of ALL a users Files (This could take a while.)
            _Files = DaimtoGoogleDriveHelper.GetFiles(service, null);

            foreach (File item in _Files)
            {
                Console.WriteLine(item.Title + " " + item.MimeType);
            }       

        }
    }
}
