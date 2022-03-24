using GestionFlux.Core.Domain;
using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Matricule { get; set; }
        public int Password { get; set; }
        public virtual Department Department { get; set; }

    }
}
