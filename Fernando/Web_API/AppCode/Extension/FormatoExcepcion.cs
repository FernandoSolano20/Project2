using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excepciones;
using Newtonsoft.Json;

namespace Web_API.AppCode.Extension
{
    public static class FormatoExcepcion
    {
        public static string Format(this BusinessException bex)
        {
            return JsonConvert.SerializeObject(bex.AppMessage);
        }
    }
}