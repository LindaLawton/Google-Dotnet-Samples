using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminSdkSample
{
    class Program
    {
        static void Main(string[] args)
        {

            var service = AuthenticationHelper.AuthenticateOauth("2046123799103-d0vpdthl4ms0soutcrpe036ckqn7rfpn.apps.googleusercontent.com", "NDmluNfTgUk6wgmy7cFo64RV", "userID");


            try
            {
                var userList = service.Users.List();
                userList.MaxResults = 10;
                userList.Execute();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);


            }

            Console.ReadLine();




        }
    }
}
