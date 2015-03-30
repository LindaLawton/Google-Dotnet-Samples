using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// Install-Package Google.Apis.YouTube.v3
namespace Daimto_YouTube_Data
{
    class Program
    {
        static void Main(string[] args)
        {

            // Authenticate Oauth2
            String CLIENT_ID = "2046123799103-d0vpdthl4ms0soutcrpe036ckqn7rfpn.apps.googleusercontent.com";
            String CLIENT_SECRET = "NDmluNfTgUk6wgmy7cFo64RV";
            var service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "test");


            int i = 1;
        }
    }
}
