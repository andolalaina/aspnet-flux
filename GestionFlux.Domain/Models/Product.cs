using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int InStock { get; set; }
        public int price { get; set; }

    }

    public class ProductProfile : BaseEntity
    {
        public Product Product { get; set; }
        public int Score { get; set; }
    }
}
