using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Purchase : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
