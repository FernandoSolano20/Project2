using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_App.Controllers.Administrador
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult OferentesPendientes()
        {
            return View();
        }
    }
}