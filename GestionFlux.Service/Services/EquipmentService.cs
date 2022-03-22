using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using GestionFlux.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Services
{
    public class EquipmentService : IEquipmentService
    {
        private Repository<Equipment> equipmentRepository;
        public EquipmentService(Repository<Equipment> equipmentRepo)
        {
            this.equipmentRepository = equipmentRepo;
        }

        public IEnumerable<Equipment> GetEquipments()
        {
            return equipmentRepository.GetAll();
        }

        public void AddEquipment(Equipment equipment)
        {
            this.equipmentRepository.Insert(equipment);
        }
    }
}
