using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;

namespace Daimto_Google_Analytics_Sample
{
    public class DaimtoAnaltyicsManagmentHelper
    {
        #region Account Summaries
        
        /// <summary>
        /// Lists account summaries (lightweight tree comprised of accounts/properties/profiles) to which the user has access.
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/accountSummaries/list
        /// </summary>
        /// <param name="service">Valid authenticated Analytics Service</param>
        /// <returns>List of Account Summaries resource - https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/accountSummaries</returns>
        public static IList<AccountSummary> AccountSummaryList(AnalyticsService service)
        {

            //List all of the activities in the specified collection for the current user.  
            // Documentation: https://developers.google.com/+/api/latest/activities/list

            ManagementResource.AccountSummariesResource.ListRequest list = service.Management.AccountSummaries.List();
            list.MaxResults = 1000;

            AccountSummaries Feed = list.Execute();

            IList<AccountSummary> returnList = new List<AccountSummary>();
            //// Loop through until we arrive at an empty page
            while (Feed.Items != null)
            {
                // Adding each item  to the list.
                foreach (var item in Feed.Items)
                {
                    returnList.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (Feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = Feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                Feed = list.Execute();

            }
            return returnList;

        }
        #endregion
        #region Account

        /// <summary>
        /// Lists all accounts to which the user has access
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/accounts/list
        /// </summary>
        /// <param name="service">Valid authenticated Analytics Service</param>
        /// <returns>List of Account resource - https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/accounts </returns>
        public static IList<Account> AccountList(AnalyticsService service)
        {

            //List all of the activities in the specified collection for the current user.  
            // Documentation: https://developers.google.com/+/api/latest/activities/list

            ManagementResource.AccountsResource.ListRequest list = service.Management.Accounts.List();
            list.MaxResults = 1000;

            Accounts Feed = list.Execute();

            IList<Account> ResultList = new List<Account>();
            //// Loop through until we arrive at an empty page
            while (Feed.Items != null)
            {
                // Adding each item  to the list.
                foreach (var item in Feed.Items)
                {
                    ResultList.Add(item);                    
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (Feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = Feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                Feed = list.Execute();

            }
            return ResultList;

        }


        #endregion
        #region Web Property

        /// <summary>
        /// Gets a web property to which the user has access. 
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties/get
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <returns>A Web property resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties </returns>
        public static Webproperty WebpropertyGet(AnalyticsService service,String accountId, String webPropertyId) {
                                    
            ManagementResource.WebpropertiesResource.GetRequest get = service.Management.Webproperties.Get(accountId, webPropertyId);

            try
            {
                var WP = get.Execute();
                return WP;
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return null;
            }
            
        }


        /// <summary>
        /// Create a new property if the account has fewer than 20 properties. 
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties/insert
        /// 
        /// Beta Access: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtWebpropertyGuide#code
        /// Write operations in the Management API (e.g. create, update, delete, patch) for Web Property, View (Profile), 
        /// and Goal resources is currently available as a developer preview in limited beta. If you're interested in using these features, 
        /// request access to the beta.
        /// https://docs.google.com/forms/d/1xyjp6ca4YkGjh7TDi1Z3XyA3XHcRHkKzFentxzUrmPY/viewform
        /// 
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="accountId">Account Id </param>
        /// <param name="Name">Name of the new webProperty</param>
        /// <param name="WebsiteURL">Url for the website of the new webProperty</param>
        /// <returns>A Web property resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties </returns>
        public static Webproperty WebpropertyInsert(AnalyticsService service, String accountId, string Name, string WebsiteURL)
        {

            Webproperty body = new Webproperty();
            body.WebsiteUrl = WebsiteURL;
            body.Name = Name;

            try
            {
                Webproperty WP = service.Management.Webproperties.Insert(body, accountId).Execute();
                return WP;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }


        /// <summary>
        /// Lists web properties to which the user has access for a given account
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties/list
        /// </summary>
        /// <param name="service">Valid authenticated Analytics Service</param>
        /// <param name="accountId">Account Id </param>
        /// <returns>A Web property resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties </returns>
        public static IList<Webproperty> WebpropertyList(AnalyticsService service, String accountId)
        {

            ManagementResource.WebpropertiesResource.ListRequest list = service.Management.Webproperties.List(accountId);
            list.MaxResults = 1000;

            Webproperties Feed = list.Execute();

            IList<Webproperty> ReturnList = new List<Webproperty>();
            //// Loop through until we arrive at an empty page
            while (Feed.Items != null)
            {
                // Adding each item  to the list.
                foreach (var item in Feed.Items)
                {
                    ReturnList.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (Feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = Feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                Feed = list.Execute();

            }
            return ReturnList;

        }

        /// <summary>
        /// Patches an existing web property. This method supports patch semantics 
        /// Documentation:https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties/patch
        /// 
        /// Beta Access: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtWebpropertyGuide#code
        /// Write operations in the Management API (e.g. create, update, delete, patch) for Web Property, View (Profile), 
        /// and Goal resources is currently available as a developer preview in limited beta. If you're interested in using these features, 
        /// request access to the beta.
        /// https://docs.google.com/forms/d/1xyjp6ca4YkGjh7TDi1Z3XyA3XHcRHkKzFentxzUrmPY/viewform
        /// 
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="Body">relevant portions of a management.webproperty resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account ID to which the web property belongs </param>
        /// <param name="webPropertyId">Web property ID</param>
        /// <returns>A Web property resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties </returns>
        public static Webproperty WebpropertyPatch(AnalyticsService service, Webproperty body, String accountId, string webPropertyId)
        {

            try
            {
                Webproperty WP = service.Management.Webproperties.Patch(body, accountId, webPropertyId).Execute();
                return WP;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Update an existing web property. This method supports patch semantics 
        /// Documentation:https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties/patch
        /// 
        /// Beta Access: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtWebpropertyGuide#code
        /// Write operations in the Management API (e.g. create, update, delete, patch) for Web Property, View (Profile), 
        /// and Goal resources is currently available as a developer preview in limited beta. If you're interested in using these features, 
        /// request access to the beta.
        /// https://docs.google.com/forms/d/1xyjp6ca4YkGjh7TDi1Z3XyA3XHcRHkKzFentxzUrmPY/viewform
        /// 
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="Body">relevant portions of a management.webproperty resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account ID to which the web property belongs </param>
        /// <param name="webPropertyId">Web property ID</param>
        /// <returns>A Web property resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties </returns>
        public static Webproperty WebpropertyUpdate(AnalyticsService service, Webproperty body, String accountId, string webPropertyId)
        {

            try
            {
                Webproperty WP = service.Management.Webproperties.Update(body, accountId, webPropertyId).Execute();
                return WP;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }
        #endregion
        #region Profile(view)

        /// <summary>
        /// Gets a profile to which the user has access. 
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/profiles/get
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="profilesId">Profile Id</param>
        /// <returns>A Profile resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/profiles </returns>
        public static Profile ProfileGet(AnalyticsService service, String accountId, String webPropertyId ,String profilesId)
        {

            ManagementResource.ProfilesResource.GetRequest get = service.Management.Profiles.Get(accountId, webPropertyId, profilesId);

            try
            {
                var result = get.Execute();
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }


        /// <summary>
        /// Create a new view (profile).
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/profiles/insert
        /// 
        /// Beta Access: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtprofilesGuide#code
        /// Write operations in the Management API (e.g. create, update, delete, patch) for Web Property, View (Profile), 
        /// and Goal resources is currently available as a developer preview in limited beta. If you're interested in using these features, 
        /// request access to the beta.
        /// https://docs.google.com/forms/d/1xyjp6ca4YkGjh7TDi1Z3XyA3XHcRHkKzFentxzUrmPY/viewform
        /// 
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="body">relevant portions of a management.profiles resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="WebsiteURL">Url for the website of the new profiles</param>
        /// <returns>A Profile resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/profiles </returns>
        public static Profile profilesInsert(AnalyticsService service, Profile body, String accountId, String webPropertyId)
        {


            try
            {
                Profile result = service.Management.Profiles.Insert(body, accountId,webPropertyId).Execute();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }


        /// <summary>
        /// Lists profiles to which the user has access for a given account and web property
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/profiles/list
        /// </summary>
        /// <param name="service">Valid authenticated Analytics Service</param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <returns>A Profile resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/profiles </returns>
        public static IList<Profile> ProfileList(AnalyticsService service, String accountId, String webPropertyId)
        {

            ManagementResource.ProfilesResource.ListRequest list = service.Management.Profiles.List(accountId,webPropertyId);
            list.MaxResults = 1000;

            Profiles Feed = list.Execute();

            IList<Profile> ReturnList = new List<Profile>();
            //// Loop through until we arrive at an empty page
            while (Feed.Items != null)
            {
                // Adding each item  to the list.
                foreach (var item in Feed.Items)
                {
                    ReturnList.Add(item);
                }

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (Feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = Feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                Feed = list.Execute();

            }
            return ReturnList;

        }

        /// <summary>
        /// Updates an existing view (profile). This method supports patch semantics.
        /// Documentation:https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties/patch
        /// 
        /// Beta Access: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtprofilesGuide#code
        /// Write operations in the Management API (e.g. create, update, delete, patch) for Web Property, View (Profile), 
        /// and Goal resources is currently available as a developer preview in limited beta. If you're interested in using these features, 
        /// request access to the beta.
        /// https://docs.google.com/forms/d/1xyjp6ca4YkGjh7TDi1Z3XyA3XHcRHkKzFentxzUrmPY/viewform
        /// 
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="Body">relevant portions of a management.profiles resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account ID to which the web property belongs </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="profilesId">profile ID</param>
        /// <returns>A Web property resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties </returns>
        public static Profile ProfilePatch(AnalyticsService service, Profile body, String accountId, String webPropertyId, string profilesId)
        {

            try
            {
                Profile result = service.Management.Profiles.Patch(body, accountId,webPropertyId, profilesId).Execute();
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Updates an existing view (profile). This method supports patch semantics.
        /// Documentation:https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties/patch
        /// 
        /// Beta Access: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtprofilesGuide#code
        /// Write operations in the Management API (e.g. create, update, delete, patch) for Web Property, View (Profile), 
        /// and Goal resources is currently available as a developer preview in limited beta. If you're interested in using these features, 
        /// request access to the beta.
        /// https://docs.google.com/forms/d/1xyjp6ca4YkGjh7TDi1Z3XyA3XHcRHkKzFentxzUrmPY/viewform
        /// 
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="Body">relevant portions of a management.profiles resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account ID to which the web property belongs </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="profilesId">profile ID</param>
        /// <returns>A Web property resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties </returns>
        public static Profile ProfileUpdate(AnalyticsService service, Profile body, String accountId, String webPropertyId, string profilesId)
        {

            try
            {
                Profile result = service.Management.Profiles.Update(body, accountId, webPropertyId, profilesId).Execute();
                return result;
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
