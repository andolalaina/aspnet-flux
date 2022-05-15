using GestionFlux.Domain.Interfaces;
using GestionFlux.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class BlackBoard : BaseEntity
    {
        public Product HighValueProduct { get; set; }
        public ICollection<SuggProduct> SuggProducts { get; set; }
        public ICollection<SuggEquipment> SuggEquipments { get; set; }
        public ICollection<SuggResource> SuggResources { get; set; }

    }

    public class SuggProduct : BaseEntity, IConcurrent
    {
        public virtual Product Product { get; set; }
        public decimal SuggPrice { get; set; }
        public bool InAccess { get; set; }
    }

    public class SuggEquipment : BaseEntity, IConcurrent
    {
        public virtual Equipment Equipment{ get; set; }
        public int Quantity { get; set; }
        public bool InAccess { get; set; }
    }

    public class SuggResource: BaseEntity, IConcurrent
    {
        public virtual Resource Resource { get; set; }
        public int Quantity { get; set; }
        public bool InAccess { get; set; }
    }
}
