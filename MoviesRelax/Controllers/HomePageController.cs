using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesRelax.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}