namespace GestionFlux.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GestionFlux.Domain.Models;
    using GestionFlux.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<GestionFlux.Domain.FluxDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FluxDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Products.AddOrUpdate(x => x.Id,
                new Product() { Id = 1, Name = "Chocolatine", InStock = 10, Price = 3000, Ref = "P001", Score = 100 },
                new Product() { Id = 2, Name = "Croissant", InStock = 10, Price = 3000, Ref = "P002", Score = 100 },
                new Product() { Id = 3, Name = "Pain", InStock = 10, Price = 3000, Ref = "P003", Score = 100 }
                );

            context.Clients.AddOrUpdate(x => x.Id,
                new Client() { Id = 1, Age = 23, Locality = "Analamanga", Sex = "Homme"},
                new Client() { Id = 2, Age = 21, Locality = "Analamanga", Sex = "Femme"},
                new Client() { Id = 3, Age = 25, Locality = "Analamanga", Sex = "Homme"}
                );
        }
    }
}
