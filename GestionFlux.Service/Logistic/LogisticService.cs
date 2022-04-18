using GestionFlux.Core.Repository;
using GestionFlux.Core.Service;
using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using GestionFlux.Domain;
using GestionFlux.Service.Logistic;
using System.Collections.Generic;

namespace GestionFlux.Service.Logistic
{
    public class LogisticService : ILogisticService
    {
        private BaseRepository<Equipment, FluxDbContext> _equipmentRepository;
        public LogisticService(BaseRepository<Equipment, FluxDbContext> equipmentRepo)
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
