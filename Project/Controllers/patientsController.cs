using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using System.Web.Routing;
namespace Project.Controllers
{
    [NoDirectAccess]
    public class patientsController : Controller
    {
        private medicareEntities db = new medicareEntities();

        // GET: patients
       
        public ActionResult Display()
        {
            return View(db.patients.ToList());
        }

        // GET: patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pid,pname,age,address,pgender,pblood,pemail,password,confirmpassword")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(patient);
        }

        // GET: patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pid,pname,age,address,pgender,pblood,pemail,password,confirmpassword")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Display");
            }
            return View(patient);
        }

        // GET: patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            patient patient = db.patients.Find(id);
            db.patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Display");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Main()
        {
            try
            {
                string name = Request.Form["name"].Trim();
                string password = Request.Form["ppassword"].Trim();
                string dname = "";
                string dpassword = "";
                

                medicareEntities db = new medicareEntities();
                patient p = (from obj in db.patients where obj.pemail == name select obj).SingleOrDefault();

                dname = p.pemail;
                dpassword = p.password;
               
             
                if (name == dname.Trim() && password == dpassword.Trim())
                {
                    Session["name"] = name;
                    return View("Main");
                }
              
                else if (password != p.password.Trim())
                {
                    return Content("Invalid Password");
                }
                else
                {
                    return Content("Invalid Credentials");
                }


            }

            catch (Exception e)
            {
                return Content(e.Message + " or User not found");
            }

            //  return View();

        }


       


        public ActionResult DisplayPatientName()
        {
            string name = Request.Form["name"];
            medicareEntities db = new medicareEntities();

            var obj = from x in db.patients where x.pname == name select x;
            int count = obj.Count();

            if (count > 0)
            {
                ViewBag.patients = obj;
                return View();
            }
            else
            {
                return Content("Patients not founds");
            }

        }
    }
}
