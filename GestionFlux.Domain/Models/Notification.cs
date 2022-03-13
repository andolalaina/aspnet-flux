using GestionFlux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Notification : BaseEntity, IMessage
    {
        public string Description { get; set; }
        public DateTime SendDate { get; set; }
        public User SendTo { get; set; }
    }
}
