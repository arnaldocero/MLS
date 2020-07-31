using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MLS.Web.Controllers
{
    public class ConceptosController : Controller
    {
        // GET: ConceptosController
        public ActionResult Diagnostico()
        {
            return View();
        }

        public ActionResult Tecnico()
        {
            return View();
        }


    }
}
