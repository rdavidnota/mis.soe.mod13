using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Security.Web.Models;

namespace Security.Web.Controllers
{
    public class BaseController : Controller
    {
        [NonAction]
        public HttpClient Initial()
        {
            var Client = new HttpClient
            {
                BaseAddress = new Uri(Utils.Url_Service)
            };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return Client;
        }

        [NonAction]
        public void Api_authentication(HttpClient client)
        {
            var byteArray = Encoding.ASCII.GetBytes(Utils.AuthUser + ":" + Utils.AuthPass);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        [NonAction]

        public ResponseAPI ConsumeService(Dictionary<string, string> dict, string service, HttpMethod requestMethod)
        {
            HttpClient client = this.Initial();
            this.Api_authentication(client);

            Uri requestUri = null;

            string queryString = "";

            if (dict != null && dict.Count > 0)
            {
                StringBuilder builder = new StringBuilder();

                foreach (KeyValuePair<string, string> pair in dict)
                {
                    builder.Append(pair.Key).Append("=").Append(pair.Value).Append('&');
                }

                queryString = builder.ToString();
                // Remove the final delimiter
                queryString = queryString.TrimEnd('&');

                requestUri = new Uri(client.BaseAddress + service + "?" + queryString);
            }
            else
            {
                requestUri = new Uri(client.BaseAddress + service);
            }

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                RequestUri = requestUri,
                Method = requestMethod
            };

            var response = new ResponseAPI();

            response.Response = client.SendAsync(requestMessage).Result;
            response.Result = response.Response.Content.ReadAsStringAsync().Result;

            return response;
        }
    }
}