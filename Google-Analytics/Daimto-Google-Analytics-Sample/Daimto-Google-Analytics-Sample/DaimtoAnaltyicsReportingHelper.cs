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
        public class optionalValues
        {

            private String _Dimensions { get; set; }
            private String _Filter { get; set; }
            private String _Sort { get; set; }
            private String _Segment { get; set; }
            private int _MaxResults { get; set; }
            private DataResource.GaResource.GetRequest.SamplingLevelEnum _SampleingLevel = DataResource.GaResource.GetRequest.SamplingLevelEnum.DEFAULT;



            public String Dimensions { get { return _Dimensions; } set { _Dimensions = value; } }
            public String Filter { get { return _Filter; } set { _Filter = value; } }
            public String Sort { get { return _Sort; } set { _Sort = value; } }
            public String Segment { get { return _Segment; } set { _Segment = value; } }
            public int MaxResults { get { return _MaxResults; } set { _MaxResults = value; } }
            public DataResource.GaResource.GetRequest.SamplingLevelEnum Sampling { get { return _SampleingLevel; } set { _SampleingLevel = value; } }


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



        private static GaData ProcessResults(DataResource.GaResource.GetRequest request)
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
            GaData hold = result;
            hold.Rows = (List<IList<string>>)AllRows;

            return hold;


        }


    }
}

