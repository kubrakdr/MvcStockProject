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
    }
}