using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Domain.Models
{
    public class BlackBoard : BaseEntity
    {
        public Product ConsumerChoiceProduct { get; set; }
        public Product MostProfitableProduct { get; set; }
        public int EquipmentAssignment { get; set; } // A faire : Matrice d'affectation des ressources

    }
}
