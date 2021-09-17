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
        [NoDirectAccess]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [NoDirectAccess]
        public ActionResult AdminMain()
        {
            string name = Request.Form["name"];
            string password = Request.Form["ppassword"];

            if (name == "admin" && password == "admin")
            {
                Session["name"] = name;
                Session["pwd"] = password;
                return View();
            }else
            {
                return Content("Invalid Credentials");
            }

        }
    }
}