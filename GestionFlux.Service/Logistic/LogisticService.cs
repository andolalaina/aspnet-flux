using GestionFlux.Core.Repository;
using GestionFlux.Core.Service;
using GestionFlux.Domain.Models;
using GestionFlux.Service.Logistic;
using System.Collections.Generic;

namespace GestionFlux.Service.Logistic
{
    public class LogisticService : ILogisticService
    {
        private GenericRepository<Equipment> _equipmentRepository;
        public LogisticService(GenericRepository<Equipment> equipmentRepo)
        {
            this._equipmentRepository = equipmentRepo;
        }

        public IEnumerable<Equipment> GetEquipments()
        {
            return _equipmentRepository.GetAll();
        }

        public void AddEquipment(Equipment equipment)
        {
            this._equipmentRepository.Insert(equipment);
        }
    }
}
