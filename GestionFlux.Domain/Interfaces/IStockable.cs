using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Interfaces
{
    public interface IStockable
    {
        string Ref { get; set; }
        int InStock { get; set; }
    }
}
