using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiTSproj.Models;

namespace TiTSproj.Controllers
{
    public class ProduktyController : Controller
    {
        private Model1 db1 = new Model1();
        // GET: Produkty
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lista (string nazwaKategorii)
        {
            var kategoria = db1.Kategorie.Include("Produkt").Where(k => k.NazwaKategorii.ToUpper() == nazwaKategorii.ToUpper()).FirstOrDefault();
            var produkty = kategoria.Produkt.ToList();
            return View(produkty);
        }
        public ActionResult Szczegoly (int id)
        {
            var produkty = db1.Produkt.Find(id);
            return View(produkty);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult KategorieMenu()
        {
            var kategorie = db1.Kategorie.ToList();
            return PartialView("_KategorieMenu", kategorie);
        }
    }
}