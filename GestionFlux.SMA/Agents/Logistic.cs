using GestionFlux.Domain.Interfaces;
using GestionFlux.Domain.Models;
using GestionFlux.SMA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.SMA.Agents
{
    public class Logistic : IAgent
    {
        public BlackBoard BlackBoard { get; }
    }
}
