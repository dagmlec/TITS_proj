using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiTSproj.Models
{
    public class Produkty
    {
        [Key]
        public int ProduktId { get; set; }
        public int KategoriaID { get; set; }
        [Required(ErrorMessage = "Wprowadź nazwę produktu")]
        [StringLength(100)]
        public string NazwaProduktu { get; set; }
        public DateTime DataDodania { get; set; }
        public string NazwaPlikuObrazka { get; set; }
        public string OpisProduktu { get; set; }
        public decimal CenaProduktu { get; set; }
        public bool Bestseller { get; set; }
        public bool Ukryty { get; set; }
        public int Ilosc { get; set; } // jak już nie będzie 

        public virtual Kategoria Kategoria { get; set; }
    }
}