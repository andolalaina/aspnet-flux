using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Production
{
    public interface IProductionService
    {
        IEnumerable<ProductionViewModels.ProductionProcessDetail> GetProductionProcesses();
        void AddProductEquipmentUse(int productId, int equipmentId, int useDegradation, int useDuration);
        void RemoveProductEquipmentUse(int productId, int equipmentId);
        IEnumerable<EquipmentUse> GetProductEquipmentUses(int productId);
        bool ReplaceMaterial(int ProductId);
        void updateProductionProcess(int ProductId, ProductionViewModels.ProductionProcessDetail newProcess);
    }
}
