using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace Google_Clndr_Api_dotnet
{
    class DaimtoCalendarHelper
    {
        #region Clear       

        /// <summary>
        /// Clears a primary calendar. This operation deletes all data associated with the primary calendar of an account and cannot be undone.
        /// Documentation: https://developers.google.com/google-apps/calendar/v3/reference/calendars/clear
        /// </summary>
        /// <param name="service">Calendar identifier</param>
        /// <param name="id">If successful, this method returns an empty response body.</param>
        /// <returns></returns>
        public static CalendarsResource.ClearRequest clear(CalendarService service, string id)
        {
             try
            {
            return service.Calendars.Clear(id);


            }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
                 return null;
             }
        }

        #endregion
        #region Delete

        /// <summary>
        /// Deletes a secondary calendar.
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/calendars/delete
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <returns>If successful, this method returns an empty response body. </returns>
        public static string delete(CalendarService service, string id)
        {
            try
            {
                return service.Calendars.Delete(id).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion
        #region Get

        /// <summary>
        /// Returns metadata for a calendar. 
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/calendars/get
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <returns>Calendar resorce: https://developers.google.com/google-apps/calendar/v3/reference/calendars#resource </returns>
        public static Calendar get(CalendarService service, string id)
        {
            try
            {
               return service.Calendars.Get(id).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion


        #region Insert

        /// <summary>
        /// Creates a secondary calendar. 
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/calendars/insert
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <returns>Calendar resorce: https://developers.google.com/google-apps/calendar/v3/reference/calendars#resource </returns>
        public static Calendar insert(CalendarService service, Calendar body)
        {
            try
            {
                return service.Calendars.Insert(body).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion


        #region patch

        /// <summary>
        /// Updates metadata for a calendar. This method supports patch semantics.
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/calendars/patch
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="body">Changes you want to make:  Use var body = DaimtoCalendarHelper.get(service,id);  
        ///                    to get body then change that and pass it to the method.</param>
        /// <returns>Calendar resorce: https://developers.google.com/google-apps/calendar/v3/reference/calendars#resource </returns>
        public static Calendar patch(CalendarService service, string id, Calendar body)
        {

            try
            {
                return service.Calendars.Patch(body, id).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion

        #region update

        /// <summary>
        /// Updates metadata for a calendar.
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/calendars/update
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="body">Changes you want to make:  Use var body = DaimtoCalendarHelper.get(service,id);  
        ///                    to get body then change that and pass it to the method.</param>
        /// <returns>CalendarList resorce: https://developers.google.com/google-apps/calendar/v3/reference/calendarList#resource </returns>
        public static Calendar update(CalendarService service, string id, Calendar body)
        {

            try
            {
                return service.Calendars.Update(body, id).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion    

    }


}
