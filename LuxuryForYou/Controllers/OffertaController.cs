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
    public class OffertaController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Offerta
        public ActionResult Index()
        {
            var offerta = db.Offerta.Include(o => o.Asta).Include(o => o.Autovettura).Include(o => o.Utente);
            return View(offerta.ToList());
        }

        // GET: Offerta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offerta offerta = db.Offerta.Find(id);
            if (offerta == null)
            {
                return HttpNotFound();
            }
            return View(offerta);
        }

        // GET: Offerta/Create
        public ActionResult Create()
        {
            ViewBag.idAsta = new SelectList(db.Asta, "idAsta", "idAsta");
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello");
            ViewBag.idUtente = new SelectList(db.Utente, "idUtente", "Username");
            return View();
        }

        // POST: Offerta/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOfferta,idUtente,idAuto,OffertaFatta,DataOfferta,idAsta")] Offerta offerta)
        {
            if (ModelState.IsValid)
            {
                db.Offerta.Add(offerta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsta = new SelectList(db.Asta, "idAsta", "idAsta", offerta.idAsta);
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", offerta.idAuto);
            ViewBag.idUtente = new SelectList(db.Utente, "idUtente", "Username", offerta.idUtente);
            return View(offerta);
        }

        // GET: Offerta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offerta offerta = db.Offerta.Find(id);
            if (offerta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsta = new SelectList(db.Asta, "idAsta", "idAsta", offerta.idAsta);
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", offerta.idAuto);
            ViewBag.idUtente = new SelectList(db.Utente, "idUtente", "Username", offerta.idUtente);
            return View(offerta);
        }

        // POST: Offerta/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOfferta,idUtente,idAuto,OffertaFatta,DataOfferta,idAsta")] Offerta offerta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsta = new SelectList(db.Asta, "idAsta", "idAsta", offerta.idAsta);
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", offerta.idAuto);
            ViewBag.idUtente = new SelectList(db.Utente, "idUtente", "Username", offerta.idUtente);
            return View(offerta);
        }

        // GET: Offerta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offerta offerta = db.Offerta.Find(id);
            if (offerta == null)
            {
                return HttpNotFound();
            }
            return View(offerta);
        }

        // POST: Offerta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offerta offerta = db.Offerta.Find(id);
            db.Offerta.Remove(offerta);
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
