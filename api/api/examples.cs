using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace BrightLocalWrapper
{
    public class examples
    {
        public static void postExample()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var parameters = new api.Parameters();
            parameters.Add("name", "The Center on Park");
            parameters.Add("company-url", "www.thecenternyc.com//chiropractor-upper-east-side/");
            parameters.Add("business-category-id", "634");
            var success = request.Post("v1/clients-and-locations/clients/", parameters);
        }
        

       
    }
}