using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Security.Web.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        [NonAction]
        public List<Models.Usuario> GetListUsers()
        {
            var users = new List<Models.Usuario>();
            var resultado = this.ConsumeService(null, "users", HttpMethod.Get);

            if (resultado.Response.IsSuccessStatusCode)
            {
                users = JsonConvert.DeserializeObject<List<Models.Usuario>>(resultado.Result);
            }

            return users;
        }

        public IActionResult Index()
        {
            var users = this.GetListUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(string fullname, string document, string email, string usuario, int typeUser)
        {
            string usuario_admin = User.Claims.FirstOrDefault(f=> f.Type == "Login").Value;

            Dictionary<string, string> dict = new Dictionary<string, string>{
                    { "fullname", fullname},
                    { "document", document},
                    { "email", email},
                    { "usuario", usuario},
                    { "typeUser", Convert.ToString(typeUser)},
                    { "usuario_admin", usuario_admin},
                };

            this.ConsumeService(dict, "user", HttpMethod.Post);

            return RedirectToAction("Index","Users");
        }

        public IActionResult BlockUser(string usuario)
        {
            string usuario_admin = User.Claims.FirstOrDefault(f => f.Type == "Login").Value;

            Dictionary<string, string> dict = new Dictionary<string, string>{
                    { "usuario", usuario},
                    { "usuario_admin", usuario_admin},
                };

            this.ConsumeService(dict, "block_user", HttpMethod.Post);

            return RedirectToAction("Index", "Users");
        }
    }
}