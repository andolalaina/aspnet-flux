using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository
{
    public class FluxDbContext : DbContext
    {
        public FluxDbContext() : base("GestionFluxDb")
        {
        }
        public DbSet<BlackBoard> BlackBoards { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentUse> EquipmentUses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceUse> ResourceUses { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<SuggEquipment> SuggEquipments { get; set; }
        public DbSet<SuggProduct> SuggProducts { get; set; }
        public DbSet<SuggResource> SuggResources { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
