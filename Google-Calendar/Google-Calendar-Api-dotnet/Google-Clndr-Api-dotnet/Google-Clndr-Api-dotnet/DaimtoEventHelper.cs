using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace Google_Clndr_Api_dotnet
{
    public class DaimtoEventHelper
    {

         #region Delete

        /// <summary>
        /// Deletes an event
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/events/delete
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="eventid">Event identifier.</param>
        /// <returns>If successful, this method returns an empty response body. </returns>
        public static string delete(CalendarService service, string id,string eventid)
        {
            try
            {                
                return service.Events.Delete(id,eventid).Execute();
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
        /// Returns an event.
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/events/get
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="eventid">Event identifier.</param>
        /// <returns>Events resorce: https://developers.google.com/google-apps/calendar/v3/reference/events#resource </returns>
        public static Event get(CalendarService service, string id,string eventid)
        {
            try
            {
                return service.Events.Get(id, eventid).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion

        #region import

        /// <summary>
        /// Imports an event. This operation is used to add a private copy of an existing event to a calendar. 
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/events/import
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="body">an event</param>
        /// <returns>Events resorce: https://developers.google.com/google-apps/calendar/v3/reference/events#resource </returns>
        public static Event get(CalendarService service, string id,Event body)
        {
            try
            {
                return service.Events.Import(body,id).Execute();
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
        /// Adds an entry to the user's calendar list.  
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/calendarList/insert
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="body">an event</param>
        /// <returns>event resorce: https://developers.google.com/google-apps/calendar/v3/reference/events#resource </returns>
        public static Event insert(CalendarService service, string id, Event body)
        {
            try
            {
                return service.Events.Insert(body,id).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion


         #region instances

        /// <summary>
        /// Returns instances of the specified recurring event. 
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/events/instances
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <returns>If successful, this method returns a response body : https://developers.google.com/google-apps/calendar/v3/reference/events/instances </returns>
        public static Events instance(CalendarService service, string id,string eventid)
        {
            try
            {
                return service.Events.Instances(id,eventid).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion


        #region List

        /// <summary>
        /// There are several query Parameters that are optional this will allow you to send the ones you want.
        /// </summary>
        public class OptionalValues
        {
            private Boolean showDeleted { get; set; }
            private int maxResults { get; set; }
           


            /// <summary>
            /// Whether to include deleted events (with status equals "cancelled") in the result. Cancelled instances of recurring events
            /// (but not the underlying recurring event) will still be included if showDeleted and singleEvents are both False.
            /// If showDeleted and singleEvents are both True, only single instances of deleted events (but not the underlying 
            /// recurring events) are returned. Optional. The default is False.
            /// Documentation: https://developers.google.com/google-apps/calendar/v3/reference/events/list
            /// </summary>            
            public Boolean ShowDeleted { get { return showDeleted; } set { showDeleted = value; } }
                       

            /// <summary>
            /// Maximum number of entries returned on one result page. By default the value is 100 entries. The page size can never be larger than 2500 entries. Optional. 
            /// Documentation: https://developers.google.com/google-apps/calendar/v3/reference/events/list
            /// </summary>
            public int MaxResults { get { return maxResults; } set { maxResults = value; } }


            

            /// <summary>
            /// Constructor sets up the default values, for things that can't be null.
            /// </summary>
            public OptionalValues()
            {
                this.maxResults = 100;
                this.showDeleted = false;              
            }
        }



        public static Events list(CalendarService service, string id  ,OptionalValues optionalValues)
        {

            var request = service.Events.List(id);


            if (optionalValues == null)
            {
                request.MaxResults = 100;
            }
            else
            {
                request.MaxResults = optionalValues.MaxResults;
                request.ShowDeleted = optionalValues.ShowDeleted;
            }

            return ProcessResults(request);


        }


        // Just loops though getting all the rows.  
        private static Events ProcessResults(EventsResource.ListRequest request)
        {
            try
            {
                Events result = request.Execute();
                List<Event> allRows = new List<Event>();

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
                Events allData = result;
                allData.Items = (List<Event>)allRows;
                return allData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion

        #region move



        /// <summary>
        /// Moves an event to another calendar, i.e. changes an event's organizer.
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/events/move
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="destination">Calendar identifier of the target calendar where the event is to be moved to.</param>
        /// <returns>event resorce:https://developers.google.com/google-apps/calendar/v3/reference/events#resource </returns>
        public static Event move(CalendarService service, string id, string eventid,string destination)
        {

            try
            {
                return service.Events.Move(id,eventid, destination).Execute();
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
        /// Updates an event. This method supports patch semantics
        /// Documentation: https://developers.google.com/google-apps/calendar/v3/reference/events/patch
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="eventid">Event identifier.</param>
        /// <param name="body">Changes you want to make:  Use var body = DaimtoEventHelper.get(service,id);  
        ///                    to get body then change that and pass it to the method.</param>
        /// <returns>event resorce:https://developers.google.com/google-apps/calendar/v3/reference/events#resource  </returns>
        public static Event patch(CalendarService service, string id, string eventid, Event body)
        {

            try
            {
                return service.Events.Patch( body, id , eventid).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion


        #region quickadd 
        
         /// <summary>
        /// Creates an event based on a simple text string
        /// Documentation: https://developers.google.com/google-apps/calendar/v3/reference/events/quickAdd
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="text">The text describing the event to be created.</param>
        /// <returns>event resorce:https://developers.google.com/google-apps/calendar/v3/reference/events#resource  </returns>
        public static Event quickAdd(CalendarService service, string id, string text)
        {

            try
            {
                return service.Events.QuickAdd( id , text).Execute();
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
        /// Updates an event.
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/events/update
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="eventid">Event identifier.</param>
        /// <param name="body">Changes you want to make:  Use var body = DaimtoEventHelper.get(service,id);  
        ///                    to get body then change that and pass it to the method.</param>
        /// <returns>event resorce:https://developers.google.com/google-apps/calendar/v3/reference/events#resource  </returns>
        public static Event update(CalendarService service, string id, string eventid, Event body)
        {

            try
            {
                return service.Events.Update(body, id,eventid).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion


        #region watch

        /// <summary>
        /// Watch for changes to CalendarList resources.
        /// Documentation:https://developers.google.com/google-apps/calendar/v3/reference/events/watch
        /// </summary>
        /// <param name="service">Valid Autenticated Calendar service</param>
        /// <param name="id">Calendar identifier.</param>
        /// <param name="channel">Channel definaing what is to be watched.</param>
        /// <returns>Channel being watched </returns>
        public static Channel watch(CalendarService service, string id, Channel channel)
        {

            try
            {
                return service.Events.Watch(channel,id).Execute();
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

    

