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
    public class LoginController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl, string username, string password)
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>
                {
                    { "usuario", username },
                    { "password", password },
                };

                var resultado = this.ConsumeService(dict, "user_validate", HttpMethod.Get);

                if (resultado.Response.IsSuccessStatusCode)
                {
                    bool isOk = JsonConvert.DeserializeObject<bool>(resultado.Result);

                    if (isOk)
                    {
                        Dictionary<string, string> dict_update = new Dictionary<string, string>{
                                { "usuario", username },
                            };

                        var update_password = this.ConsumeService(dict_update, "update_password", HttpMethod.Get);
                        var vigente_password = this.ConsumeService(dict_update, "vigente_password", HttpMethod.Get);

                        bool isUpdate = false, isVigente = false;

                        if (update_password.Response.IsSuccessStatusCode)
                        {
                            isUpdate = JsonConvert.DeserializeObject<bool>(update_password.Result);
                        }

                        if (vigente_password.Response.IsSuccessStatusCode)
                        {
                            isVigente = JsonConvert.DeserializeObject<bool>(vigente_password.Result);
                        }

                        if (isUpdate)
                        {
                            return RedirectToAction("UpdatePassword", "Login", new { usuario = username, why = 1 });
                        }

                        if (!isVigente)
                        {
                            return RedirectToAction("UpdatePassword", "Login", new { usuario = username, why = 2 });
                        }

                        var usuario = this.getUser(username);
                        var claims = new List<Claim>{
                           // new Claim(ClaimTypes.Name, "Correo", ClaimTypes.Email, usuario.Email),
                            new Claim("Username",usuario.Fullname),
                            new Claim("Email",usuario.Email),
                            new Claim("Document",usuario.Document),
                            new Claim("Login",usuario.User),
                            new Claim("TypeUser",Convert.ToString(usuario.TypeUser)),
                            new Claim("Usuario",JsonConvert.SerializeObject(usuario)),
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

        [NonAction]
        public Models.Usuario getUser(string username)
        {
            var usuario = new Models.Usuario();

            Dictionary<string, string> dict = new Dictionary<string, string>(){
                { "usuario", username }
            };

            var resultado = this.ConsumeService(dict, "user", HttpMethod.Get);


            if (resultado.Response.IsSuccessStatusCode)
            {
                usuario = JsonConvert.DeserializeObject<Models.Usuario>(resultado.Result);
            }

            return usuario;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
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

        [AllowAnonymous]
        public IActionResult RescuePassword()
        {
            return View();
        }

        public IActionResult UpdatePassword(string usuario, int why, List<int> codigos = null)
        {
            ViewBag.usuario = usuario;
            ViewBag.why = why;
            ViewBag.codigos = codigos;

            return View();
        }

        [HttpPost]
        public IActionResult UpdatePass(string usuario, string document, string current_password, string new_password, string validate_password)
        {

            if (new_password.Equals(validate_password))
            {
                Dictionary<string, string> dict = new Dictionary<string, string>{
                    { "usuario", usuario},
                    { "new_password", new_password},
                    { "password", current_password},
                    { "document", document},
                };

                var resultado = this.ConsumeService(dict, "change_password", HttpMethod.Post);

                if (resultado.Response.IsSuccessStatusCode)
                {
                    var codigos = JsonConvert.DeserializeObject<List<int>>(resultado.Result);

                    if (codigos != null && codigos.Count > 0 && !codigos.Any(a => a == 0))
                    {
                        return RedirectToAction("UpdatePassword", "Login", new { usuario = usuario, codigos = codigos });
                    }
                }

            }

            return RedirectToAction("Index", "Login");
        }

        [AllowAnonymous, HttpPost]
        public IActionResult Recover(string username, string email)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>{
                    { "email", email},
                    { "usuario", username},
                };

            this.ConsumeService(dict, "rescue_password", HttpMethod.Post);

            ViewBag.recover = true;
            return View("RescuePassword");
        }


    }
}