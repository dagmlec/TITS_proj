using MvcSiteMapProvider.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiTSproj.Infrastructure;
using TiTSproj.Models;
using TiTSproj.ViewModels;

namespace TiTSproj.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db1 = new Model1();
        public ActionResult Index()
        {
            ICacheProvider cache = new DefaultCacheProvider();

            var kategorie = db1.Kategorie.ToList();
            var nowosci = db1.Produkt.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(3).ToList();
            var bestseller = db1.Produkt.Where(a => !a.Ukryty && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
           
            
            var vm = new HomeViewModel()
            {
                Kategorie = kategorie,
                Nowosci = nowosci,
                Bestsellery = bestseller
            };

            return View(vm);
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
         
    }
}