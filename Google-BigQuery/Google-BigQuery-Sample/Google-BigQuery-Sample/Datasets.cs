using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;
using Google.Apis.Services;
namespace Google_BigQuery_Sample
{
    public class Datasets
    {

        /// <summary>
        /// There are several query Parameters that are optional this will allow you to send the ones you want.
        /// </summary>
        public class OptionalValues
        {

            private Boolean showHidden { get; set; }
            private int maxResults { get; set; }

            /// <summary>
            /// Dimension or metric filters that restrict the data returned for your request. 
            /// Documentation: https://cloud.google.com/bigquery/docs/reference/v2/datasets/list
            /// </summary>
            public Boolean ShowHidden { get { return showHidden; } set { showHidden = value; } }

            /// <summary>
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page size can never be larger than 250 entries. Optional. 
            /// Documentation: https://cloud.google.com/bigquery/docs/reference/v2/datasets/list
            /// </summary>
            public int MaxResults { get { return maxResults; } set { maxResults = value; } }

            /// <summary>
            /// Constructor sets up the default values, for things that can't be null.
            /// </summary>
            public OptionalValues()
            {
                this.maxResults = 100;

                this.showHidden = false;
            }
        }

        /// <summary>
        /// Lists all the datasets in the specified project to which the caller has read access; however, a project owner can list (but not necessarily get) all datasets in his project. 
        /// 
        /// Documentation: https://cloud.google.com/bigquery/docs/reference/v2/datasets/list
        /// </summary>
        /// <param name="service"></param>
        /// <param name="projectId"></param>
        /// <param name="optionalValues"></param>
        /// <returns></returns>
        public static DatasetList list(BigqueryService service, string projectId, OptionalValues optionalValues)
        {

            var request = service.Datasets.List(projectId);


            if (optionalValues == null)
            {
                request.MaxResults = 100;
            }
            else
            {
                request.MaxResults = optionalValues.MaxResults;
                request.All = optionalValues.ShowHidden;

            }

            return ProcessResults(request);


        }


        // Just loops though getting all the rows.  
        private static DatasetList ProcessResults(DatasetsResource.ListRequest request)
        {
            try
            {
                DatasetList result = request.Execute();


                List<DatasetList.DatasetsData> allRows = new List<DatasetList.DatasetsData>();

                //// Loop through until we arrive at an empty page
                while (result.Datasets != null)
                {
                    //Add the rows to the final list
                    allRows.AddRange(result.Datasets);

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
                DatasetList allData = result;
                allData.Datasets = (List<DatasetList.DatasetsData>)allRows;
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
