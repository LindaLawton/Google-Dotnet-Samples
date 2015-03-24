using System;
using Google.Apis.Blogger.v3;
using Google.Apis.Blogger.v3.Data;

namespace Daimto_Blogger_Sample
{
  public  class Blogs
    {


      /// <summary>
        /// Retrieves a blog by its ID.  
        /// 
        /// Documentation: https://developers.google.com/blogger/docs/3.0/reference/blogs/get
        /// </summary>
        /// <param name="service">a Valid authenticated BloggerService</param>        
        /// <param name="id">The ID of the blog to get.</param>  
        /// <param name="maxPosts">Maximum number of posts to retrieve along with the blog. When this parameter is not specified, no posts will be returned as part of the blog resource.</param> 
        /// <returns></returns>
        public static Blog GetFiles(BloggerService service, string id, long maxPosts)
        {
            try
            {
                 BlogsResource.GetRequest  list = service.Blogs.Get(id);
                list.MaxPosts = maxPosts;               
                return list.Execute();               
            }
            catch (Exception ex) {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);                            
            }
            return null;
        }

      /// <summary>
        /// Retrieves a blog by URL  
        /// 
        /// Documentation: https://developers.google.com/blogger/docs/3.0/reference/blogs/getByUrl
        /// </summary>
        /// <param name="service">a Valid authenticated BloggerService</param>        
        /// <param name="url">The URL of the blog to retrieve.</param>        
        /// <returns></returns>
        public static Blog getByUrl(BloggerService service, string url)
        {
            try
            {                
                BlogsResource.GetByUrlRequest list = service.Blogs.GetByUrl(url);               
                return list.Execute();              
            }
            catch (Exception ex) {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);                            
            }
            return null;
        }
    

        /// <summary>
        /// Retrieves a list of blogs  
        /// 
        /// Documentation: https://developers.google.com/blogger/docs/3.0/reference/blogs/listByUser
        /// </summary>
        /// <param name="service">a Valid authenticated BloggerService</param>        
        /// <param name="user">The ID of the user whose blogs are to be fetched. Either the word self or the user's profile ID.</param>        
        /// <returns></returns>
        public static BlogList listByUser(BloggerService service, string user)
        {
            try
            {                
                BlogsResource.ListByUserRequest list = service.Blogs.ListByUser(user);               
                return list.Execute();              
            }
            catch (Exception ex) {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);                            
            }
            return null;
        }


    }
   
}
