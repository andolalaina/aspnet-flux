using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Production
{
    public class ProductionViewModels
    {
        public class ProductionProcessDetail { 
        
            public int Id { get; set; }
            public string Name { get; set;}
            public int InStock { get; set;}
            public ICollection<EquipmentDetail> Equipments;
            public int Quantity { get; set;}
            public int QuantitySMA { get; set;}
        }

        public class EquipmentDetail
        {
            public string Name { get; set; }
            public int Usability { get; set; }
        }

        public class ProductEquipmentUseDetail
        {
            public int ProductId { get; set; }
            public int EquipmentId { get; set; }
            public int UseDegradation { get; set; }
            public int UseDuration { get; set; }

        }
    }
}
