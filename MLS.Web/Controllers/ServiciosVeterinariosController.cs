﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MLS.Web.Controllers
{
    public class ServiciosVeterinariosController : Controller
    {
        // GET: ServiciosVeterinariosController
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
