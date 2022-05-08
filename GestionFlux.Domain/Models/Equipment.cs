using GestionFlux.Core.Domain;
using GestionFlux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Equipment : BaseEntity, IStockable
    {
        public string Name { get; set; }
        public int Usability { get; set; }
        public string Ref { get; set; }
        public int InStock { get; set; }
        public ICollection<EquipmentUse> EquipmentUses { get; set; }
    }
}
