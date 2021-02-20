using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcStok.Models.Entity;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcStokEntities1 db = new DbMvcStokEntities1(); 
       [Authorize]
        public ActionResult Index()
        {
            var kategoriler = db.tblKategori.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {

            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(tblKategori p)
        {
            db.tblKategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = db.tblKategori.Find(id);
            db.tblKategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tblKategori.Find(id);
            return View("KategoriGetir", ktgr);

        }

         public ActionResult KategoriGuncelle(tblKategori k)
        {
            var ktg = db.tblKategori.Find(k.id);
            ktg.ad = k.ad;
            db.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}