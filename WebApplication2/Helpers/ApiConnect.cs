using System;
using System.Net.Http;
using System.Text;

namespace WebApplication2.Helpers
{
    public class ApiConnect
    {

        public HttpResponseMessage PostApi(string url, string json)
        {
            var client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, content).Result;
            return result;
        }

        public HttpResponseMessage GetApi(string url, string json=null)
        {
            var client = new HttpClient();
            var result = client.GetAsync(url).Result;
            return result;
        }

        public HttpResponseMessage DeleteFromApi(string url)
        {
            var client = new HttpClient();
            var result = client.DeleteAsync(url).Result;
            return result;
        }
    }
}
