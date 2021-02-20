using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        DbMvcStokEntities1 db = new DbMvcStokEntities1();

        // GET: Musteri
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            // var musteriliste = db.tblMusteri.ToList();

            var musteriliste = db.tblMusteri.Where(x=>x.durum==true).ToList().ToPagedList(sayfa, 3);

            return View(musteriliste);
        }
        [HttpPost]
        public ActionResult  YeniMusteri(tblMusteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }

            p.durum = true;
            db.tblMusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {

            return View();
        }
        public ActionResult MusteriSil(tblMusteri p)
        {
            var musteribul = db.tblMusteri.Find(p.id);
            musteribul.durum = false;
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tblMusteri.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult MusteriGuncelle(tblMusteri t)
        {
            var mus = db.tblMusteri.Find(t.id);
            mus.ad = t.ad;
            mus.soyad = t.soyad;
            mus.sehir = t.sehir;
            mus.bakiye = t.bakiye;
            db.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}