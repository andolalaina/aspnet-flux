using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Production
{
    public class ProductionViewModels
    {
        public class ProductionProcessDetail
        {
            public string Name { get; set;}
            public int InStock { get; set;}
            public string MaterialName { get; set;}
            public string MaterialUsability { get; set;}
            public int Quantity { get; set;}
            public int QuantitySMA { get; set;}
        }
    }
}
