using codefirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace codefirst.Controllers
{
    public class DefaultController : Controller
    {
        StudentContext studentContext = new StudentContext();
        // GET: Default
        public ActionResult Index()
        {
            return View(studentContext.Students.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid == true)
            {
                studentContext.Students.Add(s);
                int a = studentContext.SaveChanges(); // return num of row
                if (a > 0)
                {
                    TempData["InsertMsg"] = "Data inserted..";
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.InsertMsg = "<script>alert('data not inserted..')</script>";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = studentContext.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                studentContext.Entry(s).State = EntityState.Modified;
                int a = studentContext.SaveChanges(); // return num of row
                if (a > 0)
                {
                    TempData["EditMsg"] = "Data Updated..";
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.InsertMsg = "<script>alert('data not Updated..')</script>";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var row = studentContext.Students.Where(model => model.Id == id).FirstOrDefault();
                if (row != null)
                {
                    studentContext.Entry(row).State = EntityState.Deleted;
                    int a = studentContext.SaveChanges(); // return num of row
                    if (a > 0)
                    {
                        TempData["DeleteMsg"] = "Data Deleted..";
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ViewBag.InsertMsg = "<script>alert('data not Deleted..')</script>";
                    }
                }
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var row = studentContext.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

    }
}