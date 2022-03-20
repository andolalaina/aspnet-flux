using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Interfaces
{
    public interface IConcurrent
    {
        bool InAccess { get; set; }
    }
}
