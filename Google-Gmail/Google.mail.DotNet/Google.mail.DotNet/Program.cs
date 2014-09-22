using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.mail.DotNet
{
    class Program
    {
        static void Main(string[] args)
        {


            string _client_id = "1046123799103-7mk8g2iok1dv9fphok8v2kv82hiqb0q6.apps.googleusercontent.com";
            string _client_secret = "GeE-cD7PtraV0LqyoxqPnOpv";

            GAAutentication Autentication = GAAutentication.Autenticate(_client_id, _client_secret);
            int i = 1;


        }
    }
}
