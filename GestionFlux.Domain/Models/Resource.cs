using GestionFlux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Resource : BaseEntity, IStockable
    {
        public string Name { get; set; }
        public string Ref { get; set; }
        public int InStock { get; set; }
    }
}
