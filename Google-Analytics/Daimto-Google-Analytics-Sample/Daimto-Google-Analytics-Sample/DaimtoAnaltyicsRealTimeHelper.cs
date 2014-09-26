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
        /// <param name="ProfileId">Profile id to request data from </param>
        /// <param name="metrics">Valid Real time Metrics (Required)</param>
        /// <param name="dimensions">Valid real time dimensions</param>
        /// <param name="filters">filters to be applied to real-time data. https://developers.google.com/analytics/devguides/reporting/core/v3/reference#filters</param>
        /// <param name="sort">sort order for real-time data https://developers.google.com/analytics/devguides/reporting/core/v3/reference#sort</param>
        /// <returns>https://developers.google.com/analytics/devguides/reporting/realtime/v3/reference/data/realtime#resource</returns>
        public static RealtimeData RealTimeGet(AnalyticsService service, string ProfileId, string metrics, String dimensions, string filters, string sort)
        {


            DataResource.RealtimeResource.GetRequest list = service.Data.Realtime.Get(ProfileId, metrics);
            list.MaxResults = 10000;


            if (!string.IsNullOrEmpty(dimensions))
            {
                list.Dimensions = dimensions;
            }

            if (!string.IsNullOrEmpty(filters))
            {
                list.Dimensions = filters;
            }
            if (!string.IsNullOrEmpty(sort))
            {
                list.Dimensions = sort;
            }

       
            RealtimeData Feed = list.Execute();


            return Feed;


        }



    }
}
