using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<Equipment> GetEquipments();
        void AddEquipment(Equipment equipment);
    }
}
