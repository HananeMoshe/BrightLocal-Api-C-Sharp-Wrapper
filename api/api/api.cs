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
        private string api_key;
        private string api_secret;

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
        public static double ConvertToUnixTimestamp()
        {
            DateTime date = DateTime.Now;
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds + 1800);
        }

        public IRestResponse Call(Method method, string endPoint, object apiParameters)
        {
            RestClient client = new RestClient();
            var expires = ConvertToUnixTimestamp();           
            client.BaseUrl = new System.Uri("https://tools.brightlocal.com/seo-tools/api/");
           
            var sig = CreateSig(this.api_key, this.api_secret, expires);
            var request = GetApiRequest(method, endPoint, this.api_key, sig, expires, apiParameters);
            var response = client.Execute(request);

            return response;


        }

        public IRestResponse Post(string endPoint, object apiParameters)
        {
            Method method = Method.POST;
            return Call(method, endPoint, apiParameters);
        }

        public IRestResponse Put(string endPoint, object apiParameters)
        {
            Method method = Method.PUT;
            return Call(method, endPoint, apiParameters);
        }

        public IRestResponse Get(string endPoint, object apiParameters)
        {
            Method method = Method.GET;
            return Call(method, endPoint, apiParameters);
        }

        public IRestResponse Delete(string endPoint, object apiParameters)
        {
            Method method = Method.DELETE;
            return Call(method, endPoint, apiParameters);
        }

        private static RestRequest GetApiRequest(Method method, string url, string api_key, string sig, double expires, object apiParameters)
        {
            RestRequest request = new RestRequest(url, method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            request.AddParameter("api-key", api_key);
            request.AddParameter("sig", sig);
            request.AddParameter("expires", expires);

            foreach (var prop in GetProperties(apiParameters))
            {
                request.AddParameter(prop.Name, prop.Value);                
            }           
            return request;

        }   

        private static IEnumerable<PropertyValue> GetProperties(object o)
        {
            if (o != null)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(o);
                foreach (PropertyDescriptor prop in props)
                {
                    object val = prop.GetValue(o);
                    if (val != null)
                    {
                        yield return new PropertyValue { Name = prop.Name, Value = val };
                    }
                }
            }
        }

        public api(string key, string secret)
        {
            api_key = key;
            api_secret = secret;

        }
        private sealed class PropertyValue
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
}