using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Response : BaseEntity
    {
        public string Message { get; set; }
        public virtual Request Request { get; set; }
    }
}
