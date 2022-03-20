using GestionFlux.Domain.Interfaces;
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

    }

    public class SuggProduct : BaseEntity, IConcurrent
    {
        public Product Product { get; set; }
        public decimal SuggPrice { get; set; }
        public bool InAccess { get; set; }
    }

    public class SuggEquipment : BaseEntity, IConcurrent
    {
        public Equipment Equipment{ get; set; }
        public int Quantity { get; set; }
        public bool InAccess { get; set; }
    }

    public class SuggResource: BaseEntity, IConcurrent
    {
        public Resource Resource { get; set; }
        public int Quantity { get; set; }
        public bool InAccess { get; set; }
    }
}
