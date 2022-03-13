using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Interfaces
{
    interface IMessage
    {
        string Description { get; set; }
        DateTime SendDate { get; set; }
        User SendTo { get; set; }
    }
}
