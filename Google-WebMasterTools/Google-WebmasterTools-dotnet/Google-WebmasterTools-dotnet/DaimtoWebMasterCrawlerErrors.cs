using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Webmasters.v3;
using Google.Apis.Webmasters.v3.Data;

namespace Google_WebmasterTools_dotnet
{
   public class DaimtoWebMasterCrawlerErrors
    {

        /// <summary>
        ///Retrieves a time series of the number of URL crawl errors per error category and platform. 
        /// Documentation: https://developers.google.com/webmaster-tools/v3/urlcrawlerrorscounts/query
        /// </summary>
        /// <param name="service"></param>
        /// <param name="site"> The site's URL, including protocol. For example: http://www.example.com/ </param>
        /// <returns>  </returns>
        public static UrlCrawlErrorsCountsQueryResponse query(WebmastersService service, string site)
        {
            
            try
            {
               var x =  service.Urlcrawlerrorscounts.Query(site).Execute();


               return x;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;
            }

        }       

    }
}
