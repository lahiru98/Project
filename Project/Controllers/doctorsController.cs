using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using System.Data.SqlClient;
namespace Project.Controllers
{
    public class doctorsController : Controller
    {
        private medicareEntities db = new medicareEntities();

        // GET: doctors
        [NoDirectAccess]
        public ActionResult Display()
        {
            return View(db.doctors.ToList());
        }

        // GET: doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "did,dname,dage,dgender,daddress,dcategory,password,confirmpassword,status")] doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.doctors.Add(doctor);
                db.SaveChanges();
                return View("Login");
            }

            return View(doctor);
        }

        // GET: doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "did,dname,dage,dgender,daddress,dcategory,password,confirmpassword,status")] doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Display");
            }
            return View(doctor);
        }

        // GET: doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            doctor doctor = db.doctors.Find(id);
            db.doctors.Remove(doctor);
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
                string name = Request.Form["email"].Trim();
                string password = Request.Form["ddpassword"].Trim();
                string dname = "";
                string dpassword = "";
                string dstatus = "";

                medicareEntities db = new medicareEntities();
                doctor d = (from obj in db.doctors where obj.daddress == name select obj).SingleOrDefault();

                dname = d.daddress;
                dpassword = d.password;
                dstatus = d.status;
                //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=medicare;Integrated Security=True;");
                //con.Open();
                //SqlCommand cmd = new SqlCommand("select dname,password,status from doctor where dname=@name", con);
                //cmd.Parameters.AddWithValue("@name", name);
                //SqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    dname = reader[0].ToString();
                //    dpassword = reader[1].ToString();
                //    dstatus = reader[2].ToString();
                //}
                if (name == dname.Trim() && password == dpassword.Trim() && dstatus.Trim() == "true")
                {
                    Session["name"] = name;
                    return View("Main");
                }
                 else if (name == dname.Trim() && password == dpassword.Trim() && dstatus.Trim() != "true")
                {
                    return Content("Wait till the admin approval");
                }else if(password!=d.password.Trim())
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
                return Content(e.Message+" or Wait till admin approval");
            }

          //  return View();

        }
    }
}
