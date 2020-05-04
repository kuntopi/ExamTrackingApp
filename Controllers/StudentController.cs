using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;
using UniversityApp.Hubs;

namespace UniversityApp.Controllers
{
    public class StudentController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();
        // GET: Student
        public ActionResult Index()
        {
            var students = from e in db.Students
                            orderby e.studentId
                           select e;
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = db.Students.Single(m => m.studentId == id);
            if (student != null)
            {
                return View(student);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student stu)
        {
            try
            {
                db.Students.Add(stu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.Students.SingleOrDefault(m => m.studentId == id);
            if (student != null)
            {
                return View(student);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                var res = db.Students.Single(m => m.studentId == id);
                if (res != null)
                {
                    student.studentId = res.studentId;
                    db.Entry(res).CurrentValues.SetValues(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var student = db.Students.Single(m => m.studentId == id);
                if (student != null)
                {
                    return View(student);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Student stu)
        {
            try
            {
                var student = db.Students.Single(m => m.studentId == id);
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
