using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudtask2.Models;

namespace crudtask2.Controllers
{
    public class DeptController : Controller
    {
        // GET: Dept
        public ActionResult Index()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var departmentlist = db.departs.ToList();
            return View(departmentlist);
        }
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(depart d)
        {
            if (ModelState.IsValid)
            {
                NORTHWNDEntities db = new NORTHWNDEntities();
                db.departs.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        //for editing
        [HttpGet]
        public ActionResult Edit(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var data = db.departs.Find(id);
            return View(data);
            
        }
        [HttpPost]
        public ActionResult Edit(depart d)
        {
            if(ModelState.IsValid)
            {
                NORTHWNDEntities db = new NORTHWNDEntities();
                db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Display(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var data = db.departs.Find(id);
            return View(data);

        }
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    NORTHWNDEntities db = new NORTHWNDEntities();
        //    var data = db.departs.Find(id);
        //    return View(data);
        //}
        //[HttpPost]
        public ActionResult Delete(depart d)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var data = db.departs.Find(d.Id);
           
            db.departs.Remove(data);
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}