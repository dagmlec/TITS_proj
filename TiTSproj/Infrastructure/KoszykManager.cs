using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiTSproj.Models;
using System.Data.Entity;

namespace TiTSproj.Infrastructure
{
    public class KoszykManager
    {
        private Model1 db1;
        private ISessionManager session;

        public KoszykManager(ISessionManager session, Model1 db1)
        {
            this.session = session;
            this.db1 = db1;
        }

        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;
            if (session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKey) == null)
            {
                koszyk = new List<PozycjaKoszyka>();
            }
            else
            {
                koszyk = session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKey) as List<PozycjaKoszyka>;
                foreach (var pozycja in koszyk)
                {
                    pozycja.Produkty = db1.Produkt.Where(k => k.ProduktId == pozycja.Produkty.ProduktId).SingleOrDefault();
                }
            }
            return koszyk;
        }

        public void DodajDoKoszyka(int produktId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Produkty.ProduktId == produktId);
            var produkt = db1.Produkt.FirstOrDefault(k => k.ProduktId == produktId);


            //else
            //{
            //    produkt.Ilosc--;

            //    db1.Entry(produkt).State = System.Data.Entity.EntityState.Modified;
            //    db1.SaveChanges();
            //}

            if (pozycjaKoszyka != null)
            {
                if (produkt.Ilosc - pozycjaKoszyka.Ilosc < 1)
                {
                    return;
                }
                pozycjaKoszyka.Ilosc++;

            }

            else
            {
                if (produkt.Ilosc <= 0)
                    return;
                var produktyDoDodania = db1.Produkt.Where(k => k.ProduktId == produktId).SingleOrDefault();

                if (produktyDoDodania != null)
                {
                    var nowaPozycjaKoszyka = new PozycjaKoszyka()
                    {
                        Produkty = produktyDoDodania,
                        Ilosc = 1,
                        Wartosc = produktyDoDodania.CenaProduktu
                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }
            }

            session.Set(Consts.KoszykSessionKey, koszyk);
        }


        public int UsunZKoszyka(int produktId)
        {
            var koszyk = PobierzKoszyk();

            var pozycjaKoszyka = koszyk.Find(k => k.Produkty.ProduktId == produktId);
            var produkt = db1.Produkt.FirstOrDefault(k => k.ProduktId == produktId);


            if (pozycjaKoszyka != null)
            {


                produkt.Ilosc++;

                //db1.Entry(produkt).CurrentValues.SetValues(produkt);

                db1.Entry(produkt).State = System.Data.Entity.EntityState.Modified;
                db1.SaveChanges();

                if (pozycjaKoszyka.Ilosc > 1)
                {
                    pozycjaKoszyka.Ilosc--;
                    return pozycjaKoszyka.Ilosc;
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }
            return 0;
        }

        public decimal PobierzWartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => (k.Ilosc * k.Produkty.CenaProduktu));
        }

        public int PobierzIloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();
            int ilosc = koszyk.Sum(k => k.Ilosc);
            return ilosc;
        }
        public Zamowienie UtworzZamowienie(Zamowienie noweZamowienie, string userId)
        {
            var koszyk = PobierzKoszyk();
            noweZamowienie.DataDodania = DateTime.Now;
            noweZamowienie.UserId = userId;

            db1.Zamowienia.Add(noweZamowienie);

            if (noweZamowienie.PozycjaZamowienia == null)
            {
                noweZamowienie.PozycjaZamowienia = new List<PozycjaZamowienia>();
            }

            decimal koszykWartosc = 0;

            foreach (var koszykElement in koszyk)
            {

                var produkt = db1.Produkt.FirstOrDefault(k => k.ProduktId == koszykElement.Produkty.ProduktId);

                //if (produkt.Ilosc <= 0)
                //{
                //    return;
                //}
                //else
                //{
                    produkt.Ilosc -= koszykElement.Ilosc;

                    db1.Entry(produkt).State = System.Data.Entity.EntityState.Modified;
                    db1.SaveChanges();
                //}

                var nowaPozycjaZamowienia = new PozycjaZamowienia()
                {
                    ProduktId = koszykElement.Produkty.ProduktId,
                    Ilosc = koszykElement.Ilosc,
                    CenaZakupu = koszykElement.Produkty.CenaProduktu
                };

                koszykWartosc += (koszykElement.Ilosc * koszykElement.Produkty.CenaProduktu);
                noweZamowienie.PozycjaZamowienia.Add(nowaPozycjaZamowienia);
            }

            noweZamowienie.WartoscZamowienia = koszykWartosc;
            db1.SaveChanges();

            return noweZamowienie;
        }
        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Consts.KoszykSessionKey, null);
        }

        public void OddajKoszyk()
        {
            var koszyk = PobierzKoszyk();
            foreach (var koszykElement in koszyk)
            {
                var produkt = db1.Produkt.FirstOrDefault(k => k.ProduktId == koszykElement.Produkty.ProduktId);
                produkt.Ilosc += koszykElement.Ilosc;
                db1.Entry(produkt).State = System.Data.Entity.EntityState.Modified;
                db1.SaveChanges();
            }
            PustyKoszyk();
        }
    }
}