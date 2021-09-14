using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminMain()
        {
            string name = Request.Form["name"];
            string password = Request.Form["password"];

            if (name == "admin" && password == "admin")
            {
                return View();
            }else
            {
                return Content("Invalid Credentials");
            }

        }
    }
}