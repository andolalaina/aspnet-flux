using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class ConsumerReport : BaseEntity
    {
        public DateTime ReportDate { get; set; }
        public Product PreferredProduct { get; set; }

    }
}
