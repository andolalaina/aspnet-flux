using GestionFlux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Product : BaseEntity, IStockable
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public decimal Price { get; set; }
        public string Ref { get; set; }
        public int InStock { get; set; }
    }

    public class EquipmentUse : BaseEntity
    {
        public Equipment Equipment { get; set; }
        public Product Product { get; set; }

        public int UseDuration { get; set; }
        public int UseDegradation { get; set; }
    }

    public class ResourceUse : BaseEntity
    {
        public Product Product { get; set; }
        public Resource Resource { get; set; }
        public int Quantity { get; set; }
    }
}
