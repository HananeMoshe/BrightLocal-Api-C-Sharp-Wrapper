using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

namespace BrightLocalWrapper
{
    public class clientExamples
    {
        public static IRestResponse addClient()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var parameters = new api.Parameters();
            parameters.Add("name", "Le Bernardin");
            parameters.Add("company-url", "http://www.example.com");
            parameters.Add("business-category-id", "791");
            var success = request.Post("v1/clients-and-locations/clients/", parameters);

            return success;
        }

        public static IRestResponse updateClient()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var parameters = new api.Parameters();
            parameters.Add("client-id", "36447");
            parameters.Add("name", "Le Bernardin Caffe");
            var success = request.Put("v1/clients-and-locations/clients/", parameters);
            // desereialize response 
            dynamic obj = JsonConvert.DeserializeObject(success.Content);
           
            return obj;
        }

        public static IRestResponse deleteClient()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var parameters = new api.Parameters();
            parameters.Add("client-id", "36447");
                  
            var success = request.Delete("v1/clients-and-locations/clients/", parameters);
            // desereialize response 
            dynamic obj = JsonConvert.DeserializeObject(success.Content);

            return obj;
        }

        public static IRestResponse getClient()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var parameters = new api.Parameters();
            var clientId = 36447;
            var success = request.Get("v1/clients-and-locations/clients/" + clientId + "", parameters);
            // desereialize response 
            dynamic obj = JsonConvert.DeserializeObject(success.Content);

            return obj;
        }

        public static IRestResponse searchClients()
        {
            api request = new api("<INSERT_API_KEY>", "<INSERT_API_SECRET>");

            var parameters = new api.Parameters();
            parameters.Add("q", "My Sample Query");            
            var success = request.Put("v1/clients-and-locations/clients/search", parameters);
            // desereialize response 
            dynamic obj = JsonConvert.DeserializeObject(success.Content);

            return obj;
        }

    }
}