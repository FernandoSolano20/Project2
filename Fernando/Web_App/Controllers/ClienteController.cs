﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_App.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Registrar()
        {
            return View();
        }
    }
}