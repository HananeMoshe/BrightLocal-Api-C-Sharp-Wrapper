using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BrightLocalWrapper
{
    public class api
    {
        // Decalre Variables
        private string api_key;
        private string api_secret;

        // Create base 64 sha1 encrypted signature
        public static string CreateSig(string apiKey, string secretKey, double expires)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secretKey);
            byte[] messageBytes = encoding.GetBytes(apiKey + expires);
            using (var hmacsha1 = new HMACSHA1(keyByte))
            {
                byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
                var signature = Convert.ToBase64String(hashmessage);
                var sig = HttpUtility.UrlEncode(signature);
                return signature;
            }

        }

        // Create expires paramater for signature and api requests
        public static double ConvertToUnixTimestamp()
        {
            DateTime date = DateTime.Now;
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc); // The seconds since the Unix Epoch (January 1 1970 00:00:00 GMT)
            TimeSpan diff = date.ToUniversalTime() - origin;  // Subtract the seconds since the Unix Epoch from today's date. 
            return Math.Floor(diff.TotalSeconds + 1800); // Not more than 1800 seconds
        }

        // Function that creates and sends the actual request.
        public IRestResponse Call(Method method, string endPoint, Dictionary<string, object> apiParameters)
        {
            // create a new restsharp client
            RestClient client = new RestClient();
            // create sxpires variable
            var expires = ConvertToUnixTimestamp();    
            // set base url   
            client.BaseUrl = new System.Uri("https://tools.brightlocal.com/seo-tools/api/");
           
            // Generate encoded signature
            var sig = CreateSig(this.api_key, this.api_secret, expires);
            // Generate the request
            var request = GetApiRequest(method, endPoint, this.api_key, sig, expires, apiParameters);
            // execure the request
            var response = client.Execute(request);
            // deserialize the response
            dynamic obj = JsonConvert.DeserializeObject(response.Content);
            return response;


        }

        // Methods for post, put, get, delete
        public IRestResponse Post(string endPoint, Dictionary<string, object> apiParameters)
        {
            Method method = Method.POST;
            return Call(method, endPoint, apiParameters);
        }

        public IRestResponse Put(string endPoint, Dictionary<string, object> apiParameters)
        {
            Method method = Method.PUT;
            return Call(method, endPoint, apiParameters);
        }

        public IRestResponse Get(string endPoint, Dictionary<string, object> apiParameters)
        {
            Method method = Method.GET;
            return Call(method, endPoint, apiParameters);
        }

        public IRestResponse Delete(string endPoint, Dictionary<string, object> apiParameters)
        {
            Method method = Method.DELETE;
            return Call(method, endPoint, apiParameters);
        }


        private static RestRequest GetApiRequest(Method method, string url, string api_key, string sig, double expires, Dictionary<string, object> apiParameters)
        {
            // Create a new restsharp request
            RestRequest request = new RestRequest(url, method);
            // Add appropriate headers to request
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            // Add key, sig and expires to request
            request.AddParameter("api-key", api_key);
            request.AddParameter("sig", sig);
            request.AddParameter("expires", expires);

            // Loop through the parameters passed in as a dictionary and add each one to a dynamic object
            var eo = new ExpandoObject();
            var eoColl = (ICollection<KeyValuePair<string, object>>)eo;
            foreach (var kvp in apiParameters)
            {
                eoColl.Add(kvp);
            }
            dynamic eoDynamic = eo;

            // Add each parameter to restsharp request
            foreach (var prop in eoDynamic)
            {
                request.AddParameter(prop.Key, prop.Value);
            }
                        
            return request;

        }

       // api class contructor
        public api(string key, string secret)
        {
            api_key = key;
            api_secret = secret;
            
        } 

        public class Parameters : Dictionary<string, object>
        {

        }


    }
}