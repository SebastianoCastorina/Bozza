using LuxuryForYou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LuxuryForYou.Controllers
{
    public class HomeController : Controller

    {
        private ModelDBContext db = new ModelDBContext();

        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username, Password")] Utente u)
        {
            Utente user = db.Utente.Find(u.idUtente);
            if (user == null)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username, Password,Nome,Cognome,Email,Indirizzo")] Utente u)
        {

           
            Utente user = db.Utente.Add(u);
        
            
      
            db.SaveChanges();
            return RedirectToAction("Index");

        


        }
    }


}

    

    
