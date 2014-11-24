using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google_WebmasterTools_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {

            string CLIENT_ID = "1046123799103-d0vpdthl4ms0soutcrpe036ckqn7rfpn.apps.googleusercontent.com";
            string CLIENT_SECRET = "NDmluNfTgUk6wgmy7cFo64RV";
            var service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "TEST");


            // List all the sites we have access to
            foreach (var site in DaimtoWebMasterSitesHelper.list(service).SiteEntry)
            {
                Console.WriteLine("Site: " + site.SiteUrl);

                // check there site maps
                var sitemaps = DaimtoWebMasterSiteMapsHelper.list(service, site.SiteUrl);
                if (sitemaps != null)
                {
                    foreach (var sitemap in sitemaps.Sitemap)
                    {
                        Console.WriteLine("Site Map: " + sitemap.Path);
                    }
                }
                // check for errors
                var errors = DaimtoWebMasterCrawlerErrors.query(service, site.SiteUrl);

                if (errors != null)
                {
                    foreach (var error in errors.CountPerTypes)
                    {

                        Console.WriteLine("Crawler Errors: " + error.Entries.Count());

                    }
                }


            }
        }
    }
}
