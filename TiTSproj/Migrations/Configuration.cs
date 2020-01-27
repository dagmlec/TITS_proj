namespace TiTSproj.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TiTSproj.Models;

    public class Configuration : DbMigrationsConfiguration<TiTSproj.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TiTSproj.Models.Model1";
        }

        protected override void Seed(TiTSproj.Models.Model1 context)
        {
            Init.SeedSklepData(context);
            Init.SeedUzytkownicy(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
