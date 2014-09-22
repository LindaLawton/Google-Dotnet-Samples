using System.Collections.Generic;
using Google.Apis.Plus.v1;
using Google.Apis.Plus.v1.Data;

namespace Diamto_Google_plus_sample
{
    public class DaimtoGooglePlusHelper
    {
        #region Person
        /// <summary>
        /// List all of the people in the specified collection
        /// documentation:  https://developers.google.com/+/api/latest/people/list
        /// </summary>
        /// <param name="service"></param>
        /// <param name="_userId">Get the collection of people for the person identified. Use "me" to indicate the authenticated user.</param>
        /// <returns></returns>
        public static IList<Person> GetAllPeople(PlusService service, string _userId)
        {
            PeopleResource.ListRequest list = service.People.List(_userId, PeopleResource.ListRequest.CollectionEnum.Visible);
            list.MaxResults = 10;
            PeopleFeed peopleFeed = list.Execute();
            IList<Person> people = new List<Person>(); 

            //// Loop through until we arrive at an empty page
            while (peopleFeed.Items != null)
            {
                // Adding each item  to the list.
                foreach (Person item in peopleFeed.Items)
                {
                    people.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (peopleFeed.NextPageToken == null)
                {
                    break;
                }

                // Prepare the next page of results
                list.PageToken = peopleFeed.NextPageToken;

                // Execute and process the next page request
                peopleFeed = list.Execute();
                
            }

            return people;

        }

        /// <summary>
        /// Get a person
        /// Documentation: https://developers.google.com/+/api/latest/people/get
        /// </summary>
        /// <param name="service"></param>
        /// <param name="_userId">Get a person's profile.If using the userId value "me", this method requires authentication using a token that has been granted the OAuth scope</param>
        /// <returns></returns>
        public static Person GetPerson(PlusService service, string _userId)
        {
            PeopleResource.GetRequest personRequest = service.People.Get(_userId);
            return personRequest.Execute();
        }

        /// <summary>
        /// Search all public profiles.
        /// Documentation: https://developers.google.com/+/api/latest/people/search
        /// </summary>
        /// <param name="service"></param>
        /// <param name="_query">Specify a query string for full text search of public text in all profiles.</param>
        /// <returns></returns>
        public static IList<Person> SearchPeople(PlusService service, string _query)
        {

            PeopleResource.SearchRequest list = service.People.Search(_query);
            list.MaxResults = 50;
            PeopleFeed peopleFeed = list.Execute();
            IList<Person> people = new List<Person>();

            //// Loop through until we arrive at an empty page
            while (peopleFeed.Items != null)
            {
                // Adding each item  to the list.
                foreach (Person item in peopleFeed.Items)
                {
                    people.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (peopleFeed.NextPageToken == null)
                {
                    break;
                }

                // Prepare the next page of results
                list.PageToken = peopleFeed.NextPageToken;

                // Execute and process the next page request
                peopleFeed = list.Execute();

            }

            return people;

        
        }

        /// <summary>
        /// List all of the people in the specified collection for a particular activity. 
        ///    The collection parameter specifies which people to list, such as people who have +1'd or reshared this activity. 
        /// Documentation: https://developers.google.com/+/api/latest/people/listByActivity
        /// </summary>
        /// <param name="service"></param>
        /// <param name="_activityId">The ID of the activity to get the list of people for.</param>
        /// <param name="_type">plusoners or resharers</param>
        /// <returns></returns>
        public static IList<Person> PeopleListByActivity(PlusService service, string _activityId , PeopleResource.ListByActivityRequest.CollectionEnum _type)
        {
            
            PeopleResource.ListByActivityRequest list = service.People.ListByActivity(_activityId,_type);
            list.MaxResults = 100;
            PeopleFeed peopleFeed = list.Execute();
            IList<Person> people = new List<Person>();

            //// Loop through until we arrive at an empty page
            while (peopleFeed.Items != null)
            {
                // Adding each item  to the list.
                foreach (Person item in peopleFeed.Items)
                {
                    people.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (peopleFeed.NextPageToken == null)
                {
                    break;
                }

                // Prepare the next page of results
                list.PageToken = peopleFeed.NextPageToken;

                // Execute and process the next page request
                peopleFeed = list.Execute();

            }

            return people;


        }
        
        #endregion

        #region Activities
        
        /// <summary>
        /// List all of the activities in the specified collection for a particular user.
        /// 
        /// Documentation: https://developers.google.com/+/api/latest/activities/list
        /// </summary>
        /// <param name="service">a Valid authenticated PlusService</param>
        /// <param name="_userId">The ID of the user to get activities for. The special value "me" can be used to indicate the authenticated user.</param>
        /// <returns></returns>
        public static IList<Activity> GetAllActivities(PlusService service, string _userId)
        {
            //List all of the activities in the specified collection for the current user.  
            // Documentation: https://developers.google.com/+/api/latest/activities/list
            ActivitiesResource.ListRequest list = service.Activities.List(_userId, ActivitiesResource.ListRequest.CollectionEnum.Public);
            list.MaxResults = 100;
            ActivityFeed activitesFeed = list.Execute();
            IList<Activity> Activites = new List<Activity>();



            //// Loop through until we arrive at an empty page
            while (activitesFeed.Items != null)
            {
                // Adding each item  to the list.
                foreach (Activity item in activitesFeed.Items)
                {
                    Activites.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (activitesFeed.NextPageToken == null)
                {
                    break;
                }

                // Prepare the next page of results
                list.PageToken = activitesFeed.NextPageToken;

                // Execute and process the next page request
                activitesFeed = list.Execute();

            }

            return Activites;
        }

        /// <summary>
        /// Get an activity
        /// Documentation: https://developers.google.com/+/api/latest/activities/get
        /// </summary>
        /// <param name="service"></param>
        /// <param name="_activityId">The ID of the activity to get.</param>
        /// <returns></returns>
        public static Activity GetActivity(PlusService service, string _activityId)
        {
            ActivitiesResource.GetRequest activityRequest = service.Activities.Get(_activityId);
            return activityRequest.Execute();
        }

        /// <summary>
        /// Search public activities.
        /// 
        /// Documentation: https://developers.google.com/+/api/latest/activities/search
        /// </summary>
        /// <param name="service">a Valid authenticated PlusService</param>
        /// <param name="_query">Full-text search query string.</param>
        /// <returns></returns>
        public static IList<Activity> SearchActivities(PlusService service, string _query)
        {
            //List all of the activities in the specified collection for the current user.  
            // Documentation: https://developers.google.com/+/api/latest/activities/list
            ActivitiesResource.SearchRequest list = service.Activities.Search(_query);
            list.MaxResults = 100;
            ActivityFeed activitesFeed = list.Execute();
            IList<Activity> Activites = new List<Activity>();



            //// Loop through until we arrive at an empty page
            while (activitesFeed.Items != null)
            {
                // Adding each item  to the list.
                foreach (Activity item in activitesFeed.Items)
                {
                    Activites.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (activitesFeed.NextPageToken == null)
                {
                    break;
                }

                // Prepare the next page of results
                list.PageToken = activitesFeed.NextPageToken;

                // Execute and process the next page request
                activitesFeed = list.Execute();

            }

            return Activites;
        }
        #endregion
        #region Comments
        

        /// <summary>
        /// List all of the comments for an activity. 
        /// Documentation:  https://developers.google.com/+/api/latest/comments/list
        /// </summary>
        /// <param name="service">a Valid authenticated PlusService</param>
        /// <param name="_activityId">The ID of the activity to get comments for.</param>
        /// <returns></returns>
        public static IList<Comment> GetAllComments(PlusService service, string _activityId)
        {
            //List all of the activities in the specified collection for the current user.  
            // Documentation: https://developers.google.com/+/api/latest/activities/list
            CommentsResource.ListRequest listComments = service.Comments.List(_activityId);


            listComments.MaxResults = 100;
            CommentFeed commentsFeed = listComments.Execute();
            IList<Comment> Comments = new List<Comment>();



            //// Loop through until we arrive at an empty page
            while (commentsFeed.Items != null)
            {
                // Adding each item  to the list.
                foreach (Comment item in commentsFeed.Items)
                {
                    Comments.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (commentsFeed.NextPageToken == null)
                {
                    break;
                }

                // Prepare the next page of results
                listComments.PageToken = commentsFeed.NextPageToken;

                // Execute and process the next page request
                commentsFeed = listComments.Execute();

            }

            return Comments;
        }


        /// <summary>
        /// Get a comment.
        /// Documentation: https://developers.google.com/+/api/latest/comments/get
        /// </summary>
        /// <param name="service"></param>
        /// <param name="_commentId">The ID of the comment to get.</param>
        /// <returns></returns>
        public static Comment Getcomment(PlusService service, string _commentId)
        {
            CommentsResource.GetRequest Request = service.Comments.Get(_commentId);
            return Request.Execute();
        }


        #endregion
    }
}
