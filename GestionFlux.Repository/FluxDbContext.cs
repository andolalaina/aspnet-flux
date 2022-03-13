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
        public DbSet<BlackBoard> BlackBoards { get; set; }
        public DbSet<ConsumerReport> ConsumerReports { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentUse> EquipmentUses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProfile> ProductProfiles { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
