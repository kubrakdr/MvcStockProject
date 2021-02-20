using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using System.Web.Security;

namespace MvcStok.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(tblAdmin a)
        {
            var bilgiler = db.tblAdmin.FirstOrDefault(x => x.kullanici == a.kullanici && x.sifre == a.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {

                return View();
            }
        }
    }
}