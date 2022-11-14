using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_App.Controllers
{
    public partial class EmpresaController : Controller
    {
        // GET: Empresa
        public virtual ActionResult Registrar()
        {
            return PartialView();
        }
    }
}