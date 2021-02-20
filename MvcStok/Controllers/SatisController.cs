using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        DbMvcStokEntities1 db = new DbMvcStokEntities1();

        public ActionResult Index()
        {
            var satislar = db.tblSatis.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //Ürünler

            List<SelectListItem> urun = (from x in db.tblUrunler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ad,
                                                Value = x.id.ToString()
                                            }).ToList();

            ViewBag.drop1 = urun;

       
            //Personel
            List<SelectListItem> per = (from x in db.tblPersonel.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad + " " + x.soyad,
                                            Value = x.id.ToString()
                                        }).ToList();

            ViewBag.drop2 = per;


            //Müşteriler

            List<SelectListItem> musteri = (from x in db.tblMusteri.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ad + " " + x.soyad,
                                                Value = x.id.ToString()
                                            }).ToList();

            ViewBag.drop3 = musteri;


            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tblSatis s)
        {
            var urun = db.tblUrunler.Where(x => x.id == s.tblUrunler.id).FirstOrDefault();
            var musteri = db.tblMusteri.Where(x => x.id == s.tblMusteri.id).FirstOrDefault();
            var personel = db.tblPersonel.Where(x => x.id == s.tblPersonel.id).FirstOrDefault();
            s.tblUrunler = urun;
            s.tblMusteri = musteri;
            s.tblPersonel = personel;

            s.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblSatis.Add(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}