using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaParagit.Models;

namespace PruebaParagit.Controllers
{
    public class HomeController : Controller
    {
        Global global = new Global();
        public ActionResult Index()
        {
          ViewBag.lista=  global.genera();
          ViewBag.lista2 = global.generamenu();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}