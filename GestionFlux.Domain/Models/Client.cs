using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Client : BaseEntity
    {
        public string Locality { get; set; }
        public int Age { get; set; }
    }
}
