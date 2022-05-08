using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionFlux.Core.Repository;
using GestionFlux.Domain;
using GestionFlux.Domain.Models;

namespace GestionFlux.Service.Production
{
    public class ProductionService : IProductionService
    {
        private IRepository<Product, FluxDbContext> _productRepository;
        private IRepository<Equipment, FluxDbContext> _equipmentRepository;
        
        public ProductionService(IRepository<Product, FluxDbContext> productRepository, IRepository<Equipment, FluxDbContext> equipmentRepository) {
            _productRepository = productRepository;
            _equipmentRepository = equipmentRepository;
        }

        public IEnumerable<ProductionViewModels.ProductionProcessDetail> GetProductionProcesses()
        {
            throw new NotImplementedException();
        }

        public bool ReplaceMaterial(int ProductId)
        {
            throw new NotImplementedException();
        }

        public void SetProductionQuantity(int ProductId, int NewQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
