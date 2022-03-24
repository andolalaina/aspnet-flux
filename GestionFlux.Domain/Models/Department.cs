using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionFlux.Core.Domain;

namespace GestionFlux.Domain.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
    }
}
