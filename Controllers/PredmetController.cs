using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class PredmetController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();
        // GET: Predmet
        public ActionResult Index()
        {
            var predmeti = from e in db.Predmets
                           orderby e.predmetId
                           select e;
            return View(predmeti);
        }

        // GET: Predmet/Details/5
        public ActionResult Details(int id)
        {
            var predmet = db.Predmets.Single(m => m.predmetId == id);
            if (predmet != null)
            {
                return View(predmet);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Predmet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predmet/Create
        [HttpPost]
        public ActionResult Create(Predmet predmet)
        {
            try
            {
                db.Predmets.Add(predmet);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Predmet/Edit/5
        public ActionResult Edit(int id)
        {
            var predmet = db.Predmets.Single(m => m.predmetId == id);
            if (predmet != null)
            {
                return View(predmet);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Predmet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Predmet predmet)
        {
            try
            {
                var res = db.Predmets.Single(m => m.predmetId == id);
                if (res != null)
                {
                    predmet.predmetId = res.predmetId;
                    db.Entry(res).CurrentValues.SetValues(predmet);
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

        // GET: Predmet/Delete/5
        public ActionResult Delete(int id)
        {
            var predmet = db.Predmets.Single(m => m.predmetId == id);
            if (predmet != null)
            {
                return View(predmet);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Predmet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var student = db.Predmets.Single(m => m.predmetId == id);
                if (student != null)
                {
                    db.Predmets.Remove(student);
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
