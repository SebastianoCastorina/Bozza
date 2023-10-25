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
    public class AutovetturaController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Autovettura
        public ActionResult Index()
        {
            var autovettura = db.Autovettura.Include(a => a.CasaMadre);
            return View(autovettura.ToList());
        }

        // GET: Autovettura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autovettura autovettura = db.Autovettura.Find(id);
            if (autovettura == null)
            {
                return HttpNotFound();
            }
            return View(autovettura);
        }

        // GET: Autovettura/Create
        public ActionResult Create()
        {
            ViewBag.idCasaMadre = new SelectList(db.CasaMadre, "idCasaMadre", "NomeCasaMadre");
            return View();
        }

        // POST: Autovettura/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAuto,NomeModello,Colore,Costo,Chilometraggio,Luogo,Anno,HasAsta,idCasaMadre,HasEpoca")] Autovettura autovettura)
        {
            if (ModelState.IsValid)
            {
                db.Autovettura.Add(autovettura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCasaMadre = new SelectList(db.CasaMadre, "idCasaMadre", "NomeCasaMadre", autovettura.idCasaMadre);
            return View(autovettura);
        }

        // GET: Autovettura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autovettura autovettura = db.Autovettura.Find(id);
            if (autovettura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCasaMadre = new SelectList(db.CasaMadre, "idCasaMadre", "NomeCasaMadre", autovettura.idCasaMadre);
            return View(autovettura);
        }

        // POST: Autovettura/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAuto,NomeModello,Colore,Costo,Chilometraggio,Luogo,Anno,HasAsta,idCasaMadre,HasEpoca")] Autovettura autovettura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autovettura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCasaMadre = new SelectList(db.CasaMadre, "idCasaMadre", "NomeCasaMadre", autovettura.idCasaMadre);
            return View(autovettura);
        }

        // GET: Autovettura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autovettura autovettura = db.Autovettura.Find(id);
            if (autovettura == null)
            {
                return HttpNotFound();
            }
            return View(autovettura);
        }

        // POST: Autovettura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autovettura autovettura = db.Autovettura.Find(id);
            db.Autovettura.Remove(autovettura);
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
