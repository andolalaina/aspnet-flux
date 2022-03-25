using GestionFlux.SMA.Interfaces;
using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.SMA.Agents
{
    public class Marketing : IAgent
    {
        private static Marketing _instance;
        public BlackBoard BlackBoard { get; }

        public static Marketing Instance()
        {
            if (_instance == null) _instance = new Marketing();
            return _instance;
        }

        public void OnProductUpdated(Object source, Product product)
        {
            System.Diagnostics.Debug.WriteLine("Updated product : ");
        }
    }
}
