using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Security.Web.Models
{
    public class ResponseAPI
    {
        public HttpResponseMessage Response { get; set; }
        public string Result { get; set; }
    }
}
