using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class AdminController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {

            return View();
        }

        [HttpPost]
         public ActionResult YeniAdmin(tblAdmin a)
        {
             db.tblAdmin.Add(a);
            db.SaveChanges();

            return RedirectToAction("Index");
            

        }

    }
}