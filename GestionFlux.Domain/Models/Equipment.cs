using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        public int Usability { get; set; }

    }

    public class EquipmentUse : BaseEntity
    {
        public Equipment Equipment { get; set; }
        public ProductProfile ProductProfile { get; set; }

        public int UseDuration { get; set; }
        public int UseDegradation { get; set; }
    }
}
