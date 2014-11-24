using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Google.Apis.Webmasters.v3;
using Google.Apis.Webmasters.v3.Data;



namespace Google_WebmasterTools_dotnet
{
    public class DaimtoWebMasterSitesHelper
    {

        /// <summary>
        /// Lists the user's Webmaster Tools sites.
        /// Documentation:   https://developers.google.com/webmaster-tools/v3/sites/list
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static SitesListResponse list(WebmastersService service)
        {

            try
            {
                var x = service.Sites.List().Execute();

                return x;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;
            }

        }


        /// <summary>
        /// Retrieves information about specific site.
        /// Documentation:   https://developers.google.com/webmaster-tools/v3/sites/get
        /// </summary>
        /// <param name="service"></param>
        /// <param name="site"> The site's URL, including protocol. For example: http://www.example.com/ </param>
        /// <returns>site resource https://developers.google.com/webmaster-tools/v3/sites#resource </returns>
        public static WmxSite get(WebmastersService service,string site)
        {

            try
            {
               return service.Sites.Get(site).Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;
            }

        }

        /// <summary>
        /// Removes a site from the set of the user's Webmaster Tools sites.
        /// Documentation:   https://developers.google.com/webmaster-tools/v3/sites/delete
        /// </summary>
        /// <param name="service"></param>
        /// <param name="site"> The site's URL, including protocol. For example: http://www.example.com/ </param>
        /// <returns>If successful, this method returns an empty response body. </returns>
        public static string add(WebmastersService service, string site)
        {

            try
            {
                return service.Sites.Add(site).Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;
            }

        }
        /// <summary>
        /// Adds a site to the set of the user's sites in Webmaster Tools.
        /// Documentation:   https://developers.google.com/webmaster-tools/v3/sites/add
        /// </summary>
        /// <param name="service"></param>
        /// <param name="site"> The site's URL, including protocol. For example: http://www.example.com/ </param>
        /// <returns>If successful, this method returns an empty response body. </returns>
        public static string delete(WebmastersService service, string site)
        {

            try
            {
                return service.Sites.Delete(site).Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;
            }

        }
    }
}
