using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MLS.Web.Controllers
{
    public class ListadePrecio : Controller
    {
        // GET: ListadePrecio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            return View();
        }


    }
}
