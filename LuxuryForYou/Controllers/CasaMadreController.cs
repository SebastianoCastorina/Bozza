using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LuxuryForYou.Models;

namespace LuxuryForYou.Controllers
{
    public class CasaMadreController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: CasaMadre
        public ActionResult Index()
        {
            return View(db.CasaMadre.ToList());
        }

        // GET: CasaMadre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasaMadre casaMadre = db.CasaMadre.Find(id);
            if (casaMadre == null)
            {
                return HttpNotFound();
            }
            return View(casaMadre);
        }

        // GET: CasaMadre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CasaMadre/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCasaMadre,NomeCasaMadre")] CasaMadre casaMadre)
        {
            if (ModelState.IsValid)
            {
                db.CasaMadre.Add(casaMadre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(casaMadre);
        }

        // GET: CasaMadre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasaMadre casaMadre = db.CasaMadre.Find(id);
            if (casaMadre == null)
            {
                return HttpNotFound();
            }
            return View(casaMadre);
        }

        // POST: CasaMadre/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCasaMadre,NomeCasaMadre")] CasaMadre casaMadre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casaMadre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(casaMadre);
        }

        // GET: CasaMadre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasaMadre casaMadre = db.CasaMadre.Find(id);
            if (casaMadre == null)
            {
                return HttpNotFound();
            }
            return View(casaMadre);
        }

        // POST: CasaMadre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CasaMadre casaMadre = db.CasaMadre.Find(id);
            db.CasaMadre.Remove(casaMadre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
