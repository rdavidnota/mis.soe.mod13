using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Security.Web.Models
{
    public class Utils
    {
        public const string Url_Service = "http://localhost:9000/";

        public const string AuthUser = "rnota";
        public const string AuthPass = "mercado.nota";

        public static Usuario Usuario
        {
            get
            {
                var usuario = new Models.Usuario() { RolUser = Usuario.Types.Normal };
                if (ClaimsPrincipal.Current != null)
                {
                    var claims = ClaimsPrincipal.Current.Claims;
                    if (claims.Count() > 0)
                    {
                        string json_usuario = claims.FirstOrDefault(f => f.Type == "Usuario").Value;

                        if (!string.IsNullOrWhiteSpace(json_usuario))
                        {
                            usuario = JsonConvert.DeserializeObject<Models.Usuario>(json_usuario);
                        }
                    }
                }

                return usuario;
            }
        }
    }
}
