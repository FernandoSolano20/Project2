using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_App.Controllers.Membresía
{
    public class MembresiaController : Controller
    {
        // GET: Membresia
        public ActionResult vMembresiaFisico()
        {
            return View("vMembresia","_LayoutProveedorFisico");
        }

        public ActionResult vMembresiaJuridico()
        {
            return View("vMembresia", "_LayoutProveedorJuridico");
        }
    }
}