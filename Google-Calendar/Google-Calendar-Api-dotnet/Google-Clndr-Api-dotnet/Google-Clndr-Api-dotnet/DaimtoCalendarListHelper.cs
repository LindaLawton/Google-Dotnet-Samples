using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace Google_Clndr_Api_dotnet
{
    class DaimtoCalendarListHelper
    {

         /// <summary>
        /// There are several query Parameters that are optional this will allow you to send the ones you want.
        /// </summary>
        public class OptionalValues
        {
            private Boolean showDeleted { get; set; }
            private Boolean showHidden { get; set; }
            private int maxResults { get; set; }
            private CalendarListResource.ListRequest.MinAccessRoleEnum? minAccessRole = null;


            /// <summary>
            /// Whether to include deleted calendar list entries in the result. Optional. The default is False. 
            /// Documentation: https://developers.google.com/google-apps/calendar/v3/reference/calendarList/list
            /// </summary>            
            public Boolean ShowDeleted { get { return showDeleted; } set { showDeleted = value; } }

            /// <summary>
            /// Dimension or metric filters that restrict the data returned for your request. 
            /// Documentation: https://developers.google.com/google-apps/calendar/v3/reference/calendarList/list
            /// </summary>
            public Boolean ShowHidden { get { return showHidden; } set { showHidden = value; } }

            /// <summary>
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page size can never be larger than 250 entries. Optional. 
            /// Documentation: https://developers.google.com/google-apps/calendar/v3/reference/calendarList/list
            /// </summary>
            public int MaxResults { get { return maxResults; } set { maxResults = value; } }


            /// <summary>
            /// The minimum access role for the user in the returned entires. Optional. The default is no restriction. 
            ///Acceptable values are: •"freeBusyReader": The user can read free/busy information. 
            ///•"owner": The user can read and modify events and access control lists. 
            ///•"reader": The user can read events that are not private. 
            ///•"writer": The user can read and modify events. 
            /// Documentation: https://developers.google.com/google-apps/calendar/v3/reference/calendarList/list
            /// </summary>
            public CalendarListResource.ListRequest.MinAccessRoleEnum? MinAccessRole { get { return minAccessRole; } set { minAccessRole = value; } }

            /// <summary>
            /// Constructor sets up the default values, for things that can't be null.
            /// </summary>
            public OptionalValues()
            {
                this.maxResults = 100;
                this.showDeleted = false;
                this.showHidden = false;
                this.minAccessRole = null;
            }
        }


        public static void list(CalendarService service, OptionalValues optionalValues)
        {

            var request = service.CalendarList.List();


            if (optionalValues == null)
            {
                request.MaxResults = 100;
            }
            else
            {
                request.MaxResults = optionalValues.MaxResults;
                request.ShowDeleted = optionalValues.ShowDeleted;
                request.ShowHidden = optionalValues.ShowHidden;
                request.MinAccessRole = optionalValues.MinAccessRole;
            }

            CalendarList l =ProcessResults( request);
       
        
        }


        // Just loops though getting all the rows.  
        private static CalendarList ProcessResults(CalendarListResource.ListRequest request)
        {
            try
            {
                CalendarList result = request.Execute();
                List<CalendarListEntry> allRows = new List<CalendarListEntry>();

                //// Loop through until we arrive at an empty page
                while (result.Items != null)
                {
                    //Add the rows to the final list
                    allRows.AddRange(result.Items);

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
                CalendarList allData = result;
                allData.Items = (List<CalendarListEntry>)allRows;
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
