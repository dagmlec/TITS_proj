using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TiTSproj.Migrations;
using TiTSproj.Models;

namespace TiTSproj.Models
{
    public class Init : MigrateDatabaseToLatestVersion<Model1, Configuration>
    {
        public static void SeedSklepData(Model1 context)
        {
            var kategorie = new List<Kategoria>
            {
                new Kategoria() {KategoriaId = 1, NazwaKategorii = "ONA", NazwaPlikuIkony = "ona.png", OpisKategorii = "ubrania damskie"},
                new Kategoria() {KategoriaId = 2, NazwaKategorii = "ON", NazwaPlikuIkony = "on.png", OpisKategorii = "ubrania męskie"},
                new Kategoria() {KategoriaId = 3, NazwaKategorii = "DZIECKO", NazwaPlikuIkony = "dz.png", OpisKategorii = "ubrania dziecięce"}
            };
            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
            context.SaveChanges();

            var produkty = new List<Produkty>
            {
                new Produkty() {ProduktId = 514, NazwaProduktu = "DŻINSY MĘSKIE", KategoriaID = 2, OpisProduktu = "dżinsy męskie", CenaProduktu = 149, Bestseller = false, NazwaPlikuObrazka = "dzinsM.png", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 515, NazwaProduktu = "KOSZULA DZIECIĘCA", KategoriaID=3, CenaProduktu = 99, Bestseller = true, NazwaPlikuObrazka = "koszulaDZ.png", OpisProduktu = "koszula dziecięca - chłopiec", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 516, NazwaProduktu = "KOSZULA DAMSKA", KategoriaID=1, CenaProduktu = 89, Bestseller = false, NazwaPlikuObrazka = "koszK.png", OpisProduktu = "koszula damska", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 517, NazwaProduktu = "KOSZULA MĘSKA", KategoriaID=2, CenaProduktu = 99, Bestseller = true, NazwaPlikuObrazka = "koszM.png", OpisProduktu = "koszula męska", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 518, NazwaProduktu = "KOSZULA DZIECIĘCA", KategoriaID=3, CenaProduktu = 59, Bestseller = true, NazwaPlikuObrazka = "koszulaDZD.png", OpisProduktu = "koszula dziecięca - dziewczynka", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 519, NazwaProduktu = "SPODNIE DZIECIĘCE", KategoriaID=3, CenaProduktu = 79, Bestseller = true, NazwaPlikuObrazka = "spodDZD.png", OpisProduktu = "spodnie dziecięce - dziewczynka", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 520, NazwaProduktu = "KURTKA DZIECIĘCA", KategoriaID=3, CenaProduktu = 199, Bestseller = false, NazwaPlikuObrazka = "kurtkaDZ.png", OpisProduktu = "kurtka dziecięca - chłopiec", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 521, NazwaProduktu = "KURTKA DAMSKA", KategoriaID=1, CenaProduktu = 249, Bestseller = true, NazwaPlikuObrazka = "kurtkaK.png", OpisProduktu = "damski płaszcz", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 522, NazwaProduktu = "KURTKA MĘSKA", KategoriaID=2, CenaProduktu = 239, Bestseller = false, NazwaPlikuObrazka = "kurtkaM.png", OpisProduktu = "kurtka męska", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 523, NazwaProduktu = "SPODNIE DZIECIĘCE", KategoriaID=3, CenaProduktu = 49, Bestseller = false, NazwaPlikuObrazka = "spodDZ.png", OpisProduktu = "spodnie dziecięce - chłopiec", DataDodania = DateTime.Now, Ilosc = 5},
                new Produkty() {ProduktId = 524, NazwaProduktu = "DŻINSY DAMSKIE", KategoriaID = 1, CenaProduktu = 120, Bestseller = true, NazwaPlikuObrazka = "dzinsK.png", DataDodania = DateTime.Now, OpisProduktu = "dżinsy damskie", Ilosc = 5},
                new Produkty() {ProduktId = 525, NazwaProduktu = "KURTKA DZIECIĘCA", KategoriaID=3, CenaProduktu = 149, Bestseller = false, NazwaPlikuObrazka = "kurtkaDZD.png", OpisProduktu = "kurtka dziecięca - dziewczynka", DataDodania = DateTime.Now, Ilosc = 5}
            };
            produkty.ForEach(k => context.Produkt.AddOrUpdate(k));
            context.SaveChanges();
        }
        public static void SeedUzytkownicy(Model1 db1)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db1));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db1));

            const string name = "admin@TiTSproj.pl";
            const string password = "P@ssw0rd";
            const string roleName = "Admin";

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, DaneUzytkownika = new DaneUzytkownika() };
                var result = userManager.Create(user, password);
            }

            // utworzenie roli Admin jeśli nie istnieje 
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            // dodanie uzytkownika do roli Admin jesli juz nie jest w roli
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}