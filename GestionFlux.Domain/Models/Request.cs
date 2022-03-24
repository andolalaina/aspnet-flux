using GestionFlux.Core.Domain;
using GestionFlux.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class Request : BaseEntity, IMessage
    {
        public virtual User Sender { get; set; }
        public string Description { get; set; }
        public DateTime SendDate { get; set; }
        public User SendTo { get; set; }
    }
}
