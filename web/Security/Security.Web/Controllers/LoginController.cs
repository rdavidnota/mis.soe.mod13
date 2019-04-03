using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Security.Web.Models;

namespace Security.Web.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

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


        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl, string username, string password)
        {
            try
            {

                HttpClient client = this.Initial();
                this.Api_authentication(client);

                Dictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "usuario", username },
                    { "password", password },
                };

                StringBuilder builder = new StringBuilder();

                foreach (KeyValuePair<string, string> pair in dict)
                {
                    builder.Append(pair.Key).Append("=").Append(pair.Value).Append('&');
                }

                string queryString = builder.ToString();
                // Remove the final delimiter
                queryString = queryString.TrimEnd('&');

                HttpRequestMessage requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(client.BaseAddress + "user_validate?" + queryString),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    bool isOk = JsonConvert.DeserializeObject<bool>(result);

                    if (isOk)
                    {
                        var claims = new List<Claim>{
                            new Claim(ClaimTypes.Name, "raul", ClaimValueTypes.String, "https://soe.mis.mod13.com")
                        };

                        var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                        var userPrincipal = new ClaimsPrincipal(userIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal,
                            new AuthenticationProperties
                            {
                                ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                                IsPersistent = false,
                                AllowRefresh = false
                            });

                        return GoToReturnUrl(returnUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Login");
        }

        [AllowAnonymous]
        private IActionResult GoToReturnUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}