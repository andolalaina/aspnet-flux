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
        bool ReplaceMaterial(int ProductId);
        void SetProductionQuantity(int ProductId, int NewQuantity);
    }
}
