using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionFlux.Core.Repository;
using GestionFlux.Domain;
using GestionFlux.Domain.Models;
using GestionFlux.Repository.Product;

namespace GestionFlux.Service.Production
{
    public class ProductionService : IProductionService
    {
        private IProductRepository<Product, FluxDbContext> _productRepository;
        private IRepository<Equipment, FluxDbContext> _equipmentRepository;
        
        public ProductionService(IProductRepository<Product, FluxDbContext> productRepository, IRepository<Equipment, FluxDbContext> equipmentRepository) {
            _productRepository = productRepository;
            _equipmentRepository = equipmentRepository;
        }

        public void AddProductEquipmentUse(int productId, int equipmentId, int useDegradation, int useDuration)
        {
            _productRepository.AddEquipmentUse(productId, equipmentId, useDegradation, useDuration);
        }
        public void RemoveProductEquipmentUse(int productId, int equipmentId)
        {
            _productRepository.RemoveEquipmentUse(productId, equipmentId);
        }

        public IEnumerable<EquipmentUse> GetProductEquipmentUses(int productId)
        {
            return _productRepository.GetEquipmentUses(productId);
        }

        public IEnumerable<ProductionViewModels.ProductionProcessDetail> GetProductionProcesses()
        {
            IEnumerable<Product> products = _productRepository.GetAll();
            ICollection<ProductionViewModels.ProductionProcessDetail> productionProcesses = new List<ProductionViewModels.ProductionProcessDetail>();
            foreach (Product product in products)
            {
                ICollection<ProductionViewModels.EquipmentDetail> equipments = new List<ProductionViewModels.EquipmentDetail>();
                foreach (Equipment equipment in _productRepository.GetEquipments(product.Id))
                {
                    equipments.Add(new ProductionViewModels.EquipmentDetail {
                        Name = equipment.Name,
                        Usability = equipment.Usability
                    });
                }
                ProductionViewModels.ProductionProcessDetail productionProcessDetail = new ProductionViewModels.ProductionProcessDetail {
                    Id = product.Id,
                    Name = product.Name,
                    InStock = product.InStock,
                    Equipments = equipments,
                    Quantity = 30,
                    QuantitySMA = 30
                };
                productionProcesses.Add(productionProcessDetail);
            }
            return productionProcesses;
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
