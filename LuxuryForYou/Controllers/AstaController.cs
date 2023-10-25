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
    public class AstaController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Asta
        public ActionResult Index()
        {
            var asta = db.Asta.Include(a => a.Autovettura);
            return View(asta.ToList());
        }

        // GET: Asta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asta asta = db.Asta.Find(id);
            if (asta == null)
            {
                return HttpNotFound();
            }
            return View(asta);
        }

        // GET: Asta/Create
        public ActionResult Create()
        {
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello");
            return View();
        }

        // POST: Asta/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAsta,idAuto")] Asta asta)
        {
            if (ModelState.IsValid)
            {
                db.Asta.Add(asta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", asta.idAuto);
            return View(asta);
        }

        // GET: Asta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asta asta = db.Asta.Find(id);
            if (asta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", asta.idAuto);
            return View(asta);
        }

        // POST: Asta/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsta,idAuto")] Asta asta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", asta.idAuto);
            return View(asta);
        }

        // GET: Asta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asta asta = db.Asta.Find(id);
            if (asta == null)
            {
                return HttpNotFound();
            }
            return View(asta);
        }

        // POST: Asta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asta asta = db.Asta.Find(id);
            db.Asta.Remove(asta);
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
