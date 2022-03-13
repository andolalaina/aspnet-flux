using GestionFlux.SMA.Interfaces;
using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Agents
{
    public class Production : IAgent
    {
        public BlackBoard BlackBoard { get; }
}
}
