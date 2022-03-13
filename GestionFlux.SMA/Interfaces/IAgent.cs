using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.SMA.Interfaces
{
    interface IAgent
    {
        BlackBoard BlackBoard { get; }
    }
}
