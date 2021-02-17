using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities1 db = new DbMvcStokEntities1();

        public ActionResult Index()
        {
            var urunler = db.tblUrunler.Where(x=>x.durum==true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.tblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();

            ViewBag.dropdeger = ktg;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(tblUrunler t)
        {
            var ktgr = db.tblKategori.Where(x => x.id == t.tblKategori.id).FirstOrDefault();
            t.durum = true;
            t.tblKategori = ktgr;
            db.tblUrunler.Add(t);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(tblUrunler p)
        {
            var urunbul = db.tblUrunler.Find(p.id);
            urunbul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kat = (from x in db.tblKategori.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();

            var urn = db.tblUrunler.Find(id);
            ViewBag.urunkategori = kat;
            return View("UrunGetir", urn);

        }
        public ActionResult UrunGuncelle(tblUrunler p)
        {

            var urun = db.tblUrunler.Find(p.id);
            urun.marka = p.marka;
            urun.stok = p.stok;
            urun.satisfiyat = p.satisfiyat;
            urun.alisfiyat = p.satisfiyat;
            urun.ad = p.ad;

            var ktg = db.tblKategori.Where(x => x.id == p.tblKategori.id).FirstOrDefault();
            urun.kategori = ktg.id;
            db.SaveChanges();

            return RedirectToAction("Index");


        }



    }
}