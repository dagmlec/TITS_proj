using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiTSproj.Models
{
    public class PozycjaKoszyka
    {
        public Produkty Produkty { get; set; }
        public int Ilosc { get; set; }
        public decimal Wartosc { get; set; }
    }
}