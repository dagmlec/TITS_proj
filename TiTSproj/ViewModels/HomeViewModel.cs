using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiTSproj.Models;

namespace TiTSproj.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Kategoria> Kategorie { get; set; }
        public IEnumerable<Produkty> Nowosci { get; set; }
        public IEnumerable<Produkty> Bestsellery { get; set; }
    }
}