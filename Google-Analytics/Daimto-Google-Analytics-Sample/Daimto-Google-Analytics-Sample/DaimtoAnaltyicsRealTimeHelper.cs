/*
 * Copyright 2014 Daimto.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;
namespace Daimto_Google_Analytics_Sample
{
    public class DaimtoAnaltyicsRealTimeHelper
    {
        /// <summary>
        /// There are several query Parameters that are optional this will allow you to send the ones you want.
        /// </summary>
        public class OptionalValues
        {
            private string dimensions { get; set; }
            private string filter { get; set; }
            private string sort { get; set; }
            private string segment { get; set; }
            private int maxResults { get; set; }
            private DataResource.GaResource.GetRequest.SamplingLevelEnum sampleingLevel = DataResource.GaResource.GetRequest.SamplingLevelEnum.DEFAULT;


            /// <summary>
            /// A list of comma-separated dimensions for your Analytics data, such as ga:browser,ga:city. 
            /// Documentation: https://developers.google.com/analytics/devguides/reporting/core/v3/reference#dimensions
            /// </summary>            
            public string Dimensions { get { return dimensions; } set { dimensions = value; } }

            /// <summary>
            /// Dimension or metric filters that restrict the data returned for your request. 
            /// Documentation: https://developers.google.com/analytics/devguides/reporting/core/v3/reference#filters
            /// </summary>
            public string Filter { get { return filter; } set { filter = value; } }

            /// <summary>
            /// A list of comma-separated dimensions and metrics indicating the sorting order and sorting direction for the returned data. 
            /// Documentation:  https://developers.google.com/analytics/devguides/reporting/core/v3/reference#sort
            /// </summary>
            public string Sort { get { return sort; } set { sort = value; } }

            /// <summary>
            /// Constructor sets up the default values, for things that can't be null.
            /// </summary>
            public OptionalValues()
            {
                this.dimensions = null;
                this.filter = null;
                this.sort = null;
                this.segment = null;
            }
        }
        /// <summary>
        /// Returns real-time Google Analytics data for a view (profile).
        /// https://developers.google.com/analytics/devguides/reporting/realtime/v3/reference/data/realtime/get
        /// 
        /// 
        /// Beta:
        /// The Real Time Reporting API is currently available as a developer preview in limited beta. If you're interested in signing up, request access to the beta.
        /// https://docs.google.com/forms/d/1qfRFysCikpgCMGqgF3yXdUyQW4xAlLyjKuOoOEFN2Uw/viewform
        /// Apply for access wait 24 hours and then try you will not hear from Google when you have been approved. 
        /// 
        /// Documentation: Dimension and metric reference https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/
        /// </summary>
        /// <param name="service">Valid authenticated Google analytics service</param>
        /// <param name="profileId">Profile id to request data from </param>
        /// <param name="metrics">Valid Real time Metrics (Required)</param>
        /// <param name="optionalValues">Optional values can be null</param>
        /// <returns>https://developers.google.com/analytics/devguides/reporting/realtime/v3/reference/data/realtime#resource</returns>
        public static RealtimeData Get(AnalyticsService service, string profileId, string metrics, OptionalValues optionalValues)
        {
            try
            {

                DataResource.RealtimeResource.GetRequest request = service.Data.Realtime.Get(String.Format("ga:{0}", profileId), metrics);
                request.MaxResults = 10000;


                if (optionalValues != null)
                {
                    request.Dimensions = optionalValues.Dimensions;
                    request.Sort = optionalValues.Sort;
                    request.Filters = optionalValues.Filter;
                }


                RealtimeData feed = request.Execute();

                return feed;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;

            }


        }



    }
}
