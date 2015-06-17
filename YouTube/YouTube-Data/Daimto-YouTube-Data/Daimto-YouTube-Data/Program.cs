using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.YouTube.v3;


// Install-Package Google.Apis.YouTube.v3
namespace Daimto_YouTube_Data
{
    class Program
    {
        static void Main(string[] args)
        {

            //// Authenticate Oauth2
            //String CLIENT_ID = "2046123799103-d0vpdthl4ms0soutcrpe036ckqn7rfpn.apps.googleusercontent.com";
            //String CLIENT_SECRET = "NDmluNfTgUk6wgmy7cFo64RV";
            //YouTubeService service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "test");


            var service = Authentication.AuthenticateOauth("AIzaSyDuis0IF8wFajmmARCqp7YdqkLmd1XYx7c");

            var videoCatagories = service.VideoCategories.List("snippet");
            videoCatagories.RegionCode = "IL";
            var result = videoCatagories.Execute();

            var searchListRequest = service.Search.List("snippet");
            searchListRequest.Q = "Google"; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();

            List<string> videos = new List<string>();
            List<string> channels = new List<string>();
            List<string> playlists = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                        break;

                    case "youtube#channel":
                        channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                        break;

                    case "youtube#playlist":
                        playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                        break;
                }
            }


            Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
            Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
            Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));

            Console.ReadLine();

        }
    }
}
