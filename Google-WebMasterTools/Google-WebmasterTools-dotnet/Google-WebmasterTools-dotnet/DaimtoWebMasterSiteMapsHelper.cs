using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Webmasters.v3;
using Google.Apis.Webmasters.v3.Data;
namespace Google_WebmasterTools_dotnet
{
    public class DaimtoWebMasterSiteMapsHelper
    {

        /// <summary>
        /// Lists the sitemaps-entries submitted for this site, or included in the sitemap index file (if sitemapIndex is specified in the request).
        /// Documentation:  https://developers.google.com/webmaster-tools/v3/sitemaps/list
        /// </summary>
        /// <param name="service"></param>
        /// <param name="site"> The site's URL, including protocol. For example: http://www.example.com/ </param>
        /// <returns></returns>
        public static SitemapsListResponse list(WebmastersService service, string site)
        {

            try
            {
                var x = service.Sitemaps.List(site).Execute();

                return x;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;
            }

        }


        /// <summary>
        ///Retrieves information about a specific sitemap.
        /// Documentation:  https://developers.google.com/webmaster-tools/v3/sitemaps/get
        /// </summary>
        /// <param name="service"></param>
        /// <param name="site"> The site's URL, including protocol. For example: http://www.example.com/ </param>
        /// <param name="feedPath"> The URL of the actual sitemap. For example: http://www.example.com/sitemap.xml </param>
        /// <returns>site resource https://developers.google.com/webmaster-tools/v3/sites#resource </returns>
        public static WmxSitemap get(WebmastersService service, string site, string feedPath)
        {

            try
            {
                return  service.Sitemaps.Get(site,feedPath).Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;
            }

        }

        /// <summary>
        /// Deletes a sitemap from this site
        /// Documentation:   https://developers.google.com/webmaster-tools/v3/sitemaps/delete
        /// </summary>
        /// <param name="service"></param>
        /// <param name="site"> The site's URL, including protocol. For example: http://www.example.com/ </param>
        /// <param name="feedPath"> The URL of the actual sitemap. For example: http://www.example.com/sitemap.xml </param>
        /// <returns>If successful, this method returns an empty response body. </returns>
        public static string delete(WebmastersService service, string site, string feedPath)
        {

            try
            {
                return service.Sitemaps.Delete(site,feedPath).Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;
            }

        }
        /// <summary>
        /// Submits a sitemap for a site.
        /// Documentation:   https://developers.google.com/webmaster-tools/v3/sitemaps/submit
        /// </summary>
        /// <param name="service"></param>
        /// <param name="site"> The site's URL, including protocol. For example: http://www.example.com/ </param>
        /// <param name="feedPath"> The URL of the actual sitemap. For example: http://www.example.com/sitemap.xml </param>
        /// <returns>If successful, this method returns an empty response body. </returns>
        public static string add(WebmastersService service, string site, string feedPath)
        {

            try
            {
                return service.Sitemaps.Submit(site,feedPath).Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;
            }

        }
    }
}
