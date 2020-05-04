using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class IspitController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        // GET: Ispit
        public ActionResult Index()
        {
            List<Ispit> ispiti = initializeIspitList();
            
            return View(ispiti);
        }
        public ActionResult UpdatedList(int id)
        {
            List<Ispit> ispiti = initializeIspitList();

            Ispit newIspit = findIspit(id);

            initializeCreateViewData(newIspit);

            return View("Index", ispiti);
        }
        // GET: Ispit/Details/5
        public ActionResult Details(int id)
        {
            Ispit ispit = findIspit(id);
            if (ispit != null)
            {
                return View(ispit);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Ispit/Create
        public ActionResult Create()
        {
            initializeDropDownItems();

            return View();
        }

        // POST: Ispit/Create
        [HttpPost]
        public ActionResult Create(IspitResponse ispit)
        {
            try
            {
                Ispit newIspit = new Ispit();
                initializeIspit(newIspit, ispit);

                db.Ispits.Add(newIspit);
                db.SaveChanges();

                //List<Ispit> ispiti = initializeIspitList();

                //initializeCreateViewData(newIspit);

                return RedirectToAction("UpdatedList",new { id = newIspit.ispitId });
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Ispit/Edit/5
        public ActionResult Edit(int id)
        {
            var ispit = findIspit(id);
            if (ispit != null)
            {
                initializeDropDownItems();
                IspitResponse ispitRes = new IspitResponse(ispit);

                return View(ispitRes);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Ispit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IspitResponse ispitRes)
        {
            try
            {
                var ispit = findIspit(id);
                if (ispit != null)
                {
                    initializeIspit(ispit, ispitRes);
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

        // GET: Ispit/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var ispit = db.Ispits.Single(m => m.ispitId == id);
                if (ispit != null)
                {
                    return View(ispit);
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

        // POST: Ispit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Ispit isp)
        {
            try
            {
                var ispit = db.Ispits.Single(m => m.ispitId == id);
                if (ispit != null)
                {
                    db.Ispits.Remove(ispit);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        private Ispit findIspit(int id)
        {
            Ispit ispit = db.Ispits.Single(m => m.ispitId == id);
            var predmet = db.Predmets.Single(m => m.predmetId == ispit.predmetId);
            var student = db.Students.Single(m => m.studentId == ispit.studentId);
            ispit.student = student;
            ispit.predmet = predmet;
            return ispit;
        }
        [NonAction]
        private void initializeDropDownItems()
        {
            var predmeti = from e in db.Predmets
                           orderby e.predmetId
                           select e;

            ViewData["nazivPredmeta"] = new SelectList(predmeti.Select(i => i.naziv));

            var studenti = from e in db.Students
                           orderby e.brIndeksa
                           select e;
            ViewData["brIndeksa"] = new SelectList(studenti.Select(i => i.brIndeksa));
        }
        [NonAction]
        private void initializeIspit(Ispit ispit, IspitResponse ispitRes)
        {
            var student = db.Students.Single(m => m.brIndeksa == ispitRes.brIndeksa);
            var predmet = db.Predmets.Single(m => m.naziv == ispitRes.nazivPredmeta);
            ispit.student = student;
            ispit.predmet = predmet;
            ispit.datumPolaganja = ispitRes.datumPolaganja;
            ispit.ocena = ispitRes.ocena;
        }
        private void initializeCreateViewData(Ispit ispit)
        {
            ViewData["noviIspit"] = "true";
            ViewData["brIndeksa"] = ispit.student.brIndeksa;
            ViewData["predmet"] = ispit.predmet.naziv;
            ViewData["ocena"] = ispit.ocena;
            ViewData["datum"] = ispit.datumPolaganja;
            ViewData["ispitId"] = ispit.ispitId;
        }
        [NonAction]
        private List<Ispit> initializeIspitList() {
            var data = from e in db.Ispits
                       orderby e.ispitId ascending
                       select e;
            List<Ispit> ispiti = data.ToList();
            List<IspitResponse> ispitiRes = new List<IspitResponse>();
            foreach (Ispit i in ispiti)
            {
                var pr = db.Predmets.Single(m => m.predmetId == i.predmetId);
                var st = db.Students.Single(m => m.studentId == i.studentId);
                i.student = st;
                i.predmet = pr;
            }
            return ispiti;
        }
    }
}
