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
using Google.Apis.AnalyticsReporting;
using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using System.Linq;
using System.Diagnostics;


namespace Daimto.Google.Sample.Analytics
{
    public class DaimtoAnaltyicsReportingV4Helper
    {
        /// <summary>
        /// You query the Core Reporting API v4 for Google Analytics report data. 
        /// Documentation: https://developers.google.com/analytics/devguides/reporting/core/v4
        /// 
        /// Dimension and metric reference : https://developers.google.com/analytics/devguides/reporting/core/dimsmets
        /// </summary>
        /// <param name="service">Valid Authenticated ReportingServicve </param>
        /// <param name="ProfileId">The unique table ID of the form XXXX, where XXXX is the Analytics view (profile) ID for which the query will retrieve the data. </param>
        /// <param name="StartDate">Start date for fetching Analytics data. Requests can specify a start date formatted as YYYY-MM-DD, or as a relative date (e.g., today, yesterday, or NdaysAgo where N is a positive integer). </param>
        /// <param name="EndDate">End date for fetching Analytics data. Request can specify an end date formatted as YYYY-MM-DD, or as a relative date (e.g., today, yesterday, or NdaysAgo where N is a positive integer). </param>
        /// <param name="Metrics">A list of comma-separated metrics, such as ga:sessions,ga:bounces. </param>
        /// <returns></returns>
        public static IList<Report> Get(AnalyticsReportingService service, string profileId, string startDate, string endDate, string metrics, string dimensions)
        {
            // Create the DateRanges object.
            IList<DateRange> dateRangeList = new List<DateRange>();
            IList<string> startDateList = new List<string>();
            IList<string> endDateList = new List<string>();
            startDateList = startDate.Split(',').ToList();
            endDateList = endDate.Split(',').ToList();

            for (int i = 0; i < startDateList.Count; i++ )
            {
                DateRange dr = new DateRange();
                dr.StartDate = startDateList[i];
                dr.EndDate = endDateList[i];
                dateRangeList.Add(dr);
            }
            
            // Create the Metircs object.
            IList<Metric> metricsList = new List<Metric>();
            foreach( string metricString in metrics.Split(',').ToList())
            {
                Metric m = new Metric();
                m.Expression = metricString;
                metricsList.Add(m);
            }

            // Create the Dimensions object.
            IList<Dimension> dimensionsList = new List<Dimension>();
            foreach( string dimensionString in dimensions.Split(',').ToList() )
            {
                Dimension d = new Dimension();
                d.Name = dimensionString;
                dimensionsList.Add(d);
            }
            
            // Create the ReportRequest object
            ReportRequest request = new ReportRequest();
            // Assign values
            request.ViewId = profileId;
            request.DateRanges = dateRangeList;
            request.Metrics = metricsList;
            request.Dimensions = dimensionsList;

            GetReportsRequest getReport = new GetReportsRequest();
            getReport.ReportRequests = new List<ReportRequest>();
            getReport.ReportRequests.Add(request);

            GetReportsResponse getResponse = service.Reports.BatchGet(getReport).Execute();

            PrintResults(getResponse.Reports);

            return getResponse.Reports;
        }

        /// <summary>
        /// This prints 
        /// </summary>
        /// <param name="reports"></param>
        private static void PrintResults(IList<Report> reports)
        {
            foreach(Report report in reports)
            {
                ColumnHeader header = report.ColumnHeader;
                IList<string> dimensionHeaders = new List<string>();
                dimensionHeaders = header.Dimensions;

                IList<MetricHeaderEntry> metricHeaders = new List<MetricHeaderEntry>();
                metricHeaders = header.MetricHeader.MetricHeaderEntries;

                IList<ReportRow> rows = new List<ReportRow>();
                rows = report.Data.Rows;

                foreach(ReportRow row in rows)
                {
                    IList<string> dimensions = new List<string>();
                    dimensions = row.Dimensions;

                    IList<DateRangeValues> metrics = new List<DateRangeValues>();
                    metrics = row.Metrics;
                    
                    for (int i=0 ; i < dimensionHeaders.Count && i < dimensions.Count ; i++)
                    {
                        Debug.WriteLine(dimensionHeaders[i] + ": " + dimensions[i]);
                    }

                    for (int j = 0; j < metrics.Count; j++)
                    {
                        DateRangeValues values = metrics[j];               
                        for (int k = 0; k < values.Values.Count ; k++)
                        {
                            Debug.WriteLine("\t" + metricHeaders[k].Name + ": " + values.Values[k]);
                        }
                    }
                }
            }
        }


    }
}

