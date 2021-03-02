using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudtask2.Models;

namespace crudtask2.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Signup()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            ViewBag.DeptId = new SelectList(db.departs, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Signup( student s)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            if (ModelState.IsValid)
            {
                
                db.students.Add(s);
                db.SaveChanges();
               
               
            }
            ViewBag.DeptId = new SelectList(db.departs, "Id", "Name",s.DeptId);
            return RedirectToAction("Welcome");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
           if(ModelState.IsValid)
            {
                NORTHWNDEntities db = new NORTHWNDEntities();
                var data = db.students.Where(m => m.Email == email && m.Password == password).FirstOrDefault();
                if (data == null)
                {
                    ViewBag.finding = "f";
                    return View();
                }
                else
                {
                    ViewBag.finding = "g";
                    return RedirectToAction("Welcome");
                }
            }
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Enrolled()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            ViewBag.DeptId = new SelectList(db.departs, "Id", "Name");
            return View();

        }
        [HttpPost]
        public ActionResult Enrolled(int? deptid)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            ViewBag.data = db.students.Where(m => m.DeptId == deptid);
            if (ViewBag.data == null)
            {
                ViewBag.dt = "i";
            }
             ViewBag.DeptId = new SelectList(db.departs, "Id", "Name");
            return View();
        }



        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }


    }
}