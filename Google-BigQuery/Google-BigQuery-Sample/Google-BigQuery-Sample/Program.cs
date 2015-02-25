using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Services;
using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;
namespace Google_BigQuery_Sample
{
    class Program
    {
        // https://www.nuget.org/packages/Google.Apis.Bigquery.v2/
        // Install-Package Google.Apis.Bigquery.v2
        static void Main(string[] args)
        {
            BigqueryService service;
            // Authenticate Oauth2
            String CLIENT_ID = "1046123799103-d0vpdthl4ms0soutcrpe036ckqn7rfpn.apps.googleusercontent.com";
            String CLIENT_SECRET = "NDmluNfTgUk6wgmy7cFo64RV";
            service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "test");


            var project = listProjects(service).Projects.Where(a=> a.Id=="1046123799103").FirstOrDefault();

            var dataSets = Datasets.list(service, project.Id, null);




            //foreach (var x in listProjects(service).Projects.Where(a=> a.Id=="").FirstOrDefault())
            //{
            //    // 1046123799103
            //    int i = 1;

            //    Console.WriteLine(x.FriendlyName );
                
            //    Console.WriteLine(l.Datasets.Count());
            //}


            // Run the request.
            Console.WriteLine("Executing a list request...");
            //var result = await service.Apis.List().ExecuteAsync();
        }



        /// <summary>
        /// Documentation: https://cloud.google.com/bigquery/docs/reference/v2/projects/list
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static ProjectList listProjects(BigqueryService service)
        {

            var request = service.Projects.List();



            request.MaxResults = 100;



            return ProcessResults(request);


        }


        // Just loops though getting all the rows.  
        private static ProjectList ProcessResults(ProjectsResource.ListRequest request)
        {
            try
            {
                ProjectList result = request.Execute();


                List<ProjectList.ProjectsData> allRows = new List<ProjectList.ProjectsData>();

                //// Loop through until we arrive at an empty page
                while (result.Projects != null)
                {
                    //Add the rows to the final list
                    allRows.AddRange(result.Projects);

                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (result.NextPageToken == null)
                    {
                        break;
                    }
                    // Prepare the next page of results
                    request.PageToken = result.NextPageToken;

                    // Execute and process the next page request
                    result = request.Execute();

                }
                ProjectList allData = result;
                allData.Projects = (List<ProjectList.ProjectsData>)allRows;
                return allData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
