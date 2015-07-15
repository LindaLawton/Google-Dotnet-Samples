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

namespace Daimto.Google.Sample.Analytics
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
        public static AccountSummaries AccountSummaryList(AnalyticsService service)
        {

            //List all of the activities in the specified collection for the current user.  
            // Documentation: https://developers.google.com/+/api/latest/activities/list

            ManagementResource.AccountSummariesResource.ListRequest list = service.Management.AccountSummaries.List();
            list.MaxResults = 1000;  // Maximum number of Account Summaries to return per request. 

            AccountSummaries feed = list.Execute();
            List<AccountSummary> allRows = new List<AccountSummary>();

            //// Loop through until we arrive at an empty page
            while (feed.Items != null)
            {

                allRows.AddRange(feed.Items);

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                feed = list.Execute();

            }

            feed.Items = allRows;

            return feed;

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
            list.MaxResults = 1000; // Maximum number of Accounts to return, per request. 

            Accounts feed = list.Execute();

            List<Account> resultList = new List<Account>();
            //// Loop through until we arrive at an empty page
            while (feed.Items != null)
            {
                //Adding return items.
                resultList.AddRange(feed.Items);

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                feed = list.Execute();

            }
            return resultList;

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
        public static Webproperty WebpropertyGet(AnalyticsService service, string accountId, string webPropertyId)
        {

            ManagementResource.WebpropertiesResource.GetRequest get = service.Management.Webproperties.Get(accountId, webPropertyId);

            try
            {
                var wp = get.Execute();
                return wp;
            }
            catch (Exception ex)
            {

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
        /// <param name="name">Name of the new webProperty</param>
        /// <param name="websiteURL">URL for the website of the new webProperty</param>
        /// <returns>A Web property resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/webproperties </returns>
        public static Webproperty WebpropertyInsert(AnalyticsService service, string accountId, string name, string websiteURL)
        {

            Webproperty body = new Webproperty();
            body.WebsiteUrl = websiteURL;
            body.Name = name;

            try
            {
                Webproperty wp = service.Management.Webproperties.Insert(body, accountId).Execute();
                return wp;
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
        public static IList<Webproperty> WebpropertyList(AnalyticsService service, string accountId)
        {

            ManagementResource.WebpropertiesResource.ListRequest list = service.Management.Webproperties.List(accountId);
            list.MaxResults = 1000;

            Webproperties feed = list.Execute();

            List<Webproperty> returnList = new List<Webproperty>();
            //// Loop through until we arrive at an empty page
            while (feed.Items != null)
            {
                // Adding items to the list
                returnList.AddRange(feed.Items);

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                feed = list.Execute();

            }
            return returnList;

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
        public static Webproperty WebpropertyPatch(AnalyticsService service, Webproperty body, string accountId, string webPropertyId)
        {

            try
            {
                Webproperty wp = service.Management.Webproperties.Patch(body, accountId, webPropertyId).Execute();
                return wp;
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
        public static Webproperty WebpropertyUpdate(AnalyticsService service, Webproperty body, string accountId, string webPropertyId)
        {

            try
            {
                Webproperty wp = service.Management.Webproperties.Update(body, accountId, webPropertyId).Execute();
                return wp;
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
        /// <param name="profileId">Profile Id</param>
        /// <returns>A Profile resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/profiles </returns>
        public static Profile ProfileGet(AnalyticsService service, string accountId, string webPropertyId, string profileId)
        {

            ManagementResource.ProfilesResource.GetRequest get = service.Management.Profiles.Get(accountId, webPropertyId, profileId);

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
        /// <param name="WebsiteURL">URL for the website of the new profiles</param>
        /// <returns>A Profile resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/profiles </returns>
        public static Profile profilesInsert(AnalyticsService service, Profile body, string accountId, string webPropertyId)
        {


            try
            {
                Profile result = service.Management.Profiles.Insert(body, accountId, webPropertyId).Execute();
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
        public static IList<Profile> ProfileList(AnalyticsService service, string accountId, string webPropertyId)
        {

            ManagementResource.ProfilesResource.ListRequest list = service.Management.Profiles.List(accountId, webPropertyId);
            list.MaxResults = 1000;

            Profiles feed = list.Execute();

            List<Profile> returnList = new List<Profile>();
            //// Loop through until we arrive at an empty page
            while (feed.Items != null)
            {
                //Adding items to return list.
                returnList.AddRange(feed.Items);

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                feed = list.Execute();

            }
            return returnList;

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
        public static Profile ProfilePatch(AnalyticsService service, Profile body, string accountId, string webPropertyId, string profilesId)
        {

            try
            {
                Profile result = service.Management.Profiles.Patch(body, accountId, webPropertyId, profilesId).Execute();
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
        public static Profile ProfileUpdate(AnalyticsService service, Profile body, string accountId, string webPropertyId, string profilesId)
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
        #region Custom Dimensions


        /// <summary>
        /// Get a custom dimension to which the user has access 
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions/get
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="customDimensionId">Profile Id</param>
        /// <returns>A Custom Dimensions resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions#resource </returns>
        public static CustomDimension CustomDimensionGet(AnalyticsService service, string accountId, string webPropertyId, string customDimensionId)
        {

            ManagementResource.CustomDimensionsResource.GetRequest get = service.Management.CustomDimensions.Get(accountId, webPropertyId, customDimensionId);

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
        /// Create a new custom dimension
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions/insert
        /// 
        ///  Construct the body of the request and set its properties.
        ///  CustomDimension body = new CustomDimension();
        ///  body.setName("Campaign Group");
        ///  body.setScope("SESSION");
        ///  body.setActive(true);
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="body">relevant portions of a management.profiles resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="WebsiteURL">URL for the website of the new profiles</param>
        /// <returns>A Custom Dimensions resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions#resource </returns>
        public static CustomDimension CustomDimensionInsert(AnalyticsService service, CustomDimension body, string accountId, string webPropertyId)
        {


            try
            {
                CustomDimension result = service.Management.CustomDimensions.Insert(body, accountId, webPropertyId).Execute();
                return service.Management.CustomDimensions.Insert(body, accountId, webPropertyId).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }



        /// <summary>
        /// Lists custom dimensions to which the user has access.
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions/list
        /// </summary>
        /// <param name="service">Valid authenticated Analytics Service</param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <returns>Custom Dimensions resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions#resource </returns>
        public static IList<CustomDimension> CustomDimensionList(AnalyticsService service, string accountId, string webPropertyId)
        {

            ManagementResource.CustomDimensionsResource.ListRequest list = service.Management.CustomDimensions.List(accountId, webPropertyId);
            list.MaxResults = 1000;

            CustomDimensions feed = list.Execute();

            List<CustomDimension> returnList = new List<CustomDimension>();
            //// Loop through until we arrive at an empty page
            while (feed.Items != null)
            {
                //Adding items to return list.
                returnList.AddRange(feed.Items);

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                feed = list.Execute();

            }
            return returnList;

        }
        /// <summary>
        /// Updates an existing view (CustomDimension). This method supports patch semantics.
        /// Documentation:https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions/patch 
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="Body">relevant portions of a management.CustomDimension resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account ID to which the web property belongs </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="profilesId">profile ID</param>
        /// <returns>Custom Dimensions resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions#resource </returns>
        public static CustomDimension CustomDimensionPatch(AnalyticsService service, CustomDimension body, string accountId, string webPropertyId, string profilesId)
        {

            try
            {               
                return service.Management.CustomDimensions.Patch(body, accountId, webPropertyId, profilesId).Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Updates an existing view (CustomDimension). This method supports patch semantics.
        /// Documentation:https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions/update
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="Body">relevant portions of a management.CustomDimension resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account ID to which the web property belongs </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="profilesId">profile ID</param>
        /// <returns>Custom Dimensions resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customDimensions#resource </returns>
        public static CustomDimension CustomDimensionUpdate(AnalyticsService service, CustomDimension body, string accountId, string webPropertyId, string profilesId)
        {

            try
            {
                return service.Management.CustomDimensions.Update(body, accountId, webPropertyId, profilesId).Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }
        #endregion


        #region Custom Metric


        /// <summary>
        /// Get a CustomMetric to which the user has access 
        /// Documentation:https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics/get
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="customDimensionId">Profile Id</param>
        /// <returns>A CustomMetric resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics#resource </returns>
        public static CustomMetric CustomMetricGet(AnalyticsService service, string accountId, string webPropertyId, string customMetricId)
        {

            ManagementResource.CustomMetricsResource.GetRequest get = service.Management.CustomMetrics.Get(accountId, webPropertyId, customMetricId);

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
        /// Create a new CustomMetric
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics/insert
        /// 
        ///  Construct the body of the request and set its properties.
        ///CustomMetric body = new CustomMetric();
        ///body.setName("Level Completions");
        ///body.setScope("HIT");
        ///body.setType("INTEGER");
        ///body.setActive(true);
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="body">relevant portions of a management.CustomMetric resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="WebsiteURL">URL for the website of the new profiles</param>
        /// <returns>A CustomMetric resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics#resource </returns>
        public static CustomMetric CustomMetricInsert(AnalyticsService service, CustomMetric body, string accountId, string webPropertyId)
        {


            try
            {
                
                return service.Management.CustomMetrics.Insert(body, accountId, webPropertyId).Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }



        /// <summary>
        /// Lists CustomMetrics to which the user has access.
        /// Documentation: https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics/list
        /// </summary>
        /// <param name="service">Valid authenticated Analytics Service</param>
        /// <param name="accountId">Account Id </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <returns>CCustomMetric resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics#resource </returns>
        public static IList<CustomMetric> CustomMetricList(AnalyticsService service, string accountId, string webPropertyId)
        {

            ManagementResource.CustomMetricsResource.ListRequest list = service.Management.CustomMetrics.List(accountId, webPropertyId);
            list.MaxResults = 1000;

            CustomMetrics feed = list.Execute();

            List<CustomMetric> returnList = new List<CustomMetric>();
            //// Loop through until we arrive at an empty page
            while (feed.Items != null)
            {
                //Adding items to return list.
                returnList.AddRange(feed.Items);

                // We will know we are on the last page when the next page token is
                // null.
                // If this is the case, break.
                if (feed.NextLink == null)
                {
                    break;
                }

                // Prepare the next page of results             
                list.StartIndex = feed.StartIndex + list.MaxResults;
                // Execute and process the next page request
                feed = list.Execute();

            }
            return returnList;

        }
        /// <summary>
        /// Updates an existing view (CustomMetric). This method supports patch semantics.
        /// Documentation:https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics/patch
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="Body">relevant portions of a management.CustomMetric resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account ID to which the web property belongs </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="profilesId">profile ID</param>
        /// <returns>CustomMetric resource https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics#resource </returns>
        public static CustomMetric CustomMetricPatch(AnalyticsService service, CustomMetric body, string accountId, string webPropertyId, string profilesId)
        {

            try
            {
                return service.Management.CustomMetrics.Patch(body, accountId, webPropertyId, profilesId).Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Updates an existing view (CustomMetric). This method supports patch semantics.
        /// Documentation:https://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics/update
        /// 
        /// </summary>
        /// <param name="service">Valid Authenticated Analytics Service </param>
        /// <param name="Body">relevant portions of a management.CustomMetric resource, according to the rules of patch semantics.</param>
        /// <param name="accountId">Account ID to which the web property belongs </param>
        /// <param name="webPropertyId">Web property Id</param>
        /// <param name="profilesId">profile ID</param>
        /// <returns>CustomMetric resourcehttps://developers.google.com/analytics/devguides/config/mgmt/v3/mgmtReference/management/customMetrics#resource </returns>
        public static CustomMetric CustomMetricUpdate(AnalyticsService service, CustomMetric body, string accountId, string webPropertyId, string profilesId)
        {

            try
            {
                return service.Management.CustomMetrics.Update(body, accountId, webPropertyId, profilesId).Execute();
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
