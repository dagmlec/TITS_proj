using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiTSproj.Models;

namespace TiTSproj.ViewModels
{
    public class KoszykViewModel
    {
        public List<PozycjaKoszyka> PozycjeKoszyka { get; set; }
        public decimal CenaCalkowita { get; set; }
        
    }
}