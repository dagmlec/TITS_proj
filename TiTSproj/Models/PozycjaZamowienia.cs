using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiTSproj.Models
{
    public class PozycjaZamowienia
    {
        public int PozycjaZamowieniaId { get; set; }
        public int ZamowienieID { get; set; }
        public int ProduktId { get; set; }
        public int Ilosc { get; set; }
        public decimal CenaZakupu { get; set; }

        public virtual Produkty Produkt { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}