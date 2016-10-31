using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrightLocalWrapper
{
    public class locationExamples
    {
        public static IRestResponse addLocation()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var parameters = new api.Parameters();
            parameters.Add("name", "Le Bernardin");
            parameters.Add("url", "http://le-bernardin.com");
            parameters.Add("business-category-id", "605");
            parameters.Add("country", "USA"); // 3 Letter iso code
            parameters.Add("address1", "155 Weest 51st Street");
            parameters.Add("address2", "");
            parameters.Add("region", "NY"); // State or Region
            parameters.Add("city", "New York");
            parameters.Add("postcode", "10019");
            parameters.Add("telephone", "+1 212-554-1515");

            var success = request.Post("v1/clients-and-locations/locations/", parameters);

            return success;
        }

        public static IRestResponse updateLocation()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var locationId = 1;
            var parameters = new api.Parameters();
            parameters.Add("name", "Le Bernardin");
            parameters.Add("url", "http://le-bernardin.com");
            parameters.Add("business-category-id", "605");
            parameters.Add("country", "USA"); // 3 Letter iso code
            parameters.Add("address1", "155 Weest 51st Street");
            parameters.Add("address2", "");
            parameters.Add("region", "NY"); // State or Region
            parameters.Add("city", "New York");
            parameters.Add("postcode", "10019");
            parameters.Add("telephone", "+1 212-554-1515");

            var success = request.Put("v1/clients-and-locations/locations/" + locationId + "", parameters);
            // desereialize response 
            dynamic obj = JsonConvert.DeserializeObject(success.Content);

            return obj;
        }

        public static IRestResponse deleteLocation()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var locationId = 1;
            var parameters = new api.Parameters();

            var success = request.Delete("v1/clients-and-locations/locations/" + locationId + "", parameters);
            // desereialize response 
            dynamic obj = JsonConvert.DeserializeObject(success.Content);

            return obj;
        }

        public static IRestResponse getLocation()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var locationId = 1;
            var parameters = new api.Parameters();

            var success = request.Get("v1/clients-and-locations/locations/" + locationId + "", parameters);
            // desereialize response 
            dynamic obj = JsonConvert.DeserializeObject(success.Content);

            return obj;
        }

        public static IRestResponse searchLocation()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var parameters = new api.Parameters();
            parameters.Add("q", "My Sample Query");

            var success = request.Get("v1/clients-and-locations/locations/search", parameters);
            // desereialize response 
            dynamic obj = JsonConvert.DeserializeObject(success.Content);

            return obj;
        }

    }
}