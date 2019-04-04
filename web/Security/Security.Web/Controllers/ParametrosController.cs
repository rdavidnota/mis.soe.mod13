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
    public class ParametrosController : BaseController
    {
        public IActionResult Index()
        {
            var resultado = this.ConsumeService(null, "configuration", HttpMethod.Get);
            var configuration = new Models.Configuration();

            if (resultado.Response.IsSuccessStatusCode)
            {
                configuration = JsonConvert.DeserializeObject<Models.Configuration>(resultado.Result);
            }

            return View(configuration);
        }

        public IActionResult Change(int level, int min_digits, int min_letters, int min_capitals, int min_special, int longitud, int max_days)
        {
            if (level == 0)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>{
                    { "level", Convert.ToString(level)},
                    { "min_digits", Convert.ToString(min_digits)},
                    { "min_letters", Convert.ToString(min_letters)},
                    { "min_capitals", Convert.ToString(min_capitals)},
                    { "min_special", Convert.ToString(min_special)},
                    { "longitud", Convert.ToString(longitud)},
                    { "max_days", Convert.ToString(max_days)}
                };
                this.ConsumeService(dict, "configuration", HttpMethod.Post);
            }
            else
            {
                Dictionary<string, string> dict = new Dictionary<string, string>{
                    { "level", Convert.ToString(level)},
                };
                this.ConsumeService(dict, "configuration", HttpMethod.Post);
            }

            return RedirectToAction("Index", "Parametros");
        }
    }
}