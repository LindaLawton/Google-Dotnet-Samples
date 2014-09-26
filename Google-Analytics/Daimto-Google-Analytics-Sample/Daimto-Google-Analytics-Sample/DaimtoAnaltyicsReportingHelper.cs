using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;

namespace Daimto_Google_Analytics_Sample
{
    public class DaimtoAnaltyicsReportingHelper
    {

        /// <summary>
        /// There are several query Parameters that are optional this will allow you to send the ones you want.
        /// </summary>
        public class optionalValues
        {
            private String _Dimensions { get; set; }
            private String _Filter { get; set; }
            private String _Sort { get; set; }
            private String _Segment { get; set; }
            private int _MaxResults { get; set; }
            private DataResource.GaResource.GetRequest.SamplingLevelEnum _SampleingLevel = DataResource.GaResource.GetRequest.SamplingLevelEnum.DEFAULT;


            /// <summary>
            /// A list of comma-separated dimensions for your Analytics data, such as ga:browser,ga:city. 
            /// Documentation: https://developers.google.com/analytics/devguides/reporting/core/v3/reference#dimensions
            /// </summary>            
            public String Dimensions { get { return _Dimensions; } set { _Dimensions = value; } }

            /// <summary>
            /// Dimension or metric filters that restrict the data returned for your request. 
            /// Documentation: https://developers.google.com/analytics/devguides/reporting/core/v3/reference#filters
            /// </summary>
            public String Filter { get { return _Filter; } set { _Filter = value; } }

            /// <summary>
            /// A list of comma-separated dimensions and metrics indicating the sorting order and sorting direction for the returned data. 
            /// Documentation:  https://developers.google.com/analytics/devguides/reporting/core/v3/reference#sort
            /// </summary>
            public String Sort { get { return _Sort; } set { _Sort = value; } }

            /// <summary>            
            /// Segments the data returned for your request. 
            /// Documentation: https://developers.google.com/analytics/devguides/reporting/core/v3/reference#segment
            /// </summary>
            public String Segment { get { return _Segment; } set { _Segment = value; } }

            /// <summary>
            /// The maximum number of rows to include in the response. max is 10000
            /// </summary>
            public int MaxResults { get { return _MaxResults; } set { _MaxResults = value; } }


            /// <summary>
            /// The desired sampling level. 
            /// Allowed Values: 
            /// •DEFAULT — Returns response with a sample size that balances speed and accuracy.
            /// •FASTER — Returns a fast response with a smaller sample size.
            /// •HIGHER_PRECISION — Returns a more accurate response using a large sample size, but this may result in the response being slower.
            /// Documentation: https://developers.google.com/analytics/devguides/reporting/core/v3/reference#samplingLevel
            /// </summary>
            public DataResource.GaResource.GetRequest.SamplingLevelEnum Sampling { get { return _SampleingLevel; } set { _SampleingLevel = value; } }

            /// <summary>
            /// Constructor sets up the default values, for things that can't be null.
            /// </summary>
            public optionalValues()
            {
                this._Dimensions = null;
                this._Filter = null;
                this._Sort = null;
                this._Segment = null;
                this._SampleingLevel = DataResource.GaResource.GetRequest.SamplingLevelEnum.DEFAULT;
                this._MaxResults = 1000;
            }
        }


        /// <summary>
        /// You query the Core Reporting API for Google Analytics report data. 
        /// Documentation: https://developers.google.com/analytics/devguides/reporting/core/v3/reference
        /// 
        /// Dimension and metric refrence : https://developers.google.com/analytics/devguides/reporting/core/dimsmets
        /// </summary>
        /// <param name="service">Valid Authenticated AnalyticsServicve </param>
        /// <param name="ProfileId">The unique table ID of the form XXXX, where XXXX is the Analytics view (profile) ID for which the query will retrieve the data. </param>
        /// <param name="StartDate">Start date for fetching Analytics data. Requests can specify a start date formatted as YYYY-MM-DD, or as a relative date (e.g., today, yesterday, or NdaysAgo where N is a positive integer). </param>
        /// <param name="EndDate">End date for fetching Analytics data. Request can specify an end date formatted as YYYY-MM-DD, or as a relative date (e.g., today, yesterday, or NdaysAgo where N is a positive integer). </param>
        /// <param name="Metrics">A list of comma-separated metrics, such as ga:sessions,ga:bounces. </param>
        /// <param name="MyValues">Optional values can be null </param>
        /// <returns></returns>
        public static GaData get(AnalyticsService service, String ProfileId, String StartDate, String EndDate, String Metrics, optionalValues MyValues)
        {

            DataResource.GaResource.GetRequest request = service.Data.Ga.Get("ga:" + ProfileId, StartDate, EndDate, Metrics);

            if (MyValues == null)
            {
                request.MaxResults = 1000;
            }
            else
            {
                request.MaxResults = MyValues.MaxResults;
                request.Dimensions = MyValues.Dimensions;
                request.SamplingLevel = MyValues.Sampling;
                request.Segment = MyValues.Segment;
                request.Sort = MyValues.Sort;
                request.Filters = MyValues.Filter;

            }
            return ProcessResults(request);
        }


        // Just loops though getting all the rows.  
        private static GaData ProcessResults(DataResource.GaResource.GetRequest request)
        {
            try
            {
                GaData result = request.Execute();
                List<IList<string>> AllRows = new List<IList<string>>();

                //// Loop through until we arrive at an empty page
                while (result.Rows != null)
                {
                    //Add the rows to the final list
                    AllRows.AddRange(result.Rows);

                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (result.NextLink == null)
                    {
                        break;
                    }

                    // Prepare the next page of results             
                    request.StartIndex = request.StartIndex + request.MaxResults;
                    // Execute and process the next page request
                    result = request.Execute();

                }
                GaData AllData = result;
                AllData.Rows = (List<IList<string>>)AllRows;
                return AllData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }




        }


    }
}

