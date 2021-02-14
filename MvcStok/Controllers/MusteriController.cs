using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1();
        // GET: Musteri
        public ActionResult Index()
        {
            var musteriliste = db.tblMusteri.ToList();

            return View(musteriliste);
        }
    }
}