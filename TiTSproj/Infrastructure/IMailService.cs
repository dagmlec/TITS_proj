﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiTSproj.Models;

namespace TiTSproj.Infrastructure
{
    public interface IMailService
    {
        void WyslaniePotwierdzenieZamowieniaEmail(Zamowienie zamowienie);
        void WyslanieZamowienieZrealizowaneEmail(Zamowienie zamowienie);
    }
}