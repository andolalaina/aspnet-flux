using GestionFlux.Core.Repository;
using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.Product
{
    public interface IProductRepository<TEntity, TContext> : IRepository<TEntity, TContext>
    {
        IEnumerable<Equipment> GetEquipments(int productId);
        IEnumerable<Resource> GetResources(int productId);
        void AddEquipmentUse(int productId, int EquipmentId, int useDegradation, int useDuration);
        void RemoveEquipmentUse(int productId, int EquipmentId);
        IEnumerable<EquipmentUse> GetEquipmentUses(int productId);
        void AddResourceUse(int productId, int resourceId, int quantity);
        void RemoveResourceUse(int productId, int resourceId);
        IEnumerable<ResourceUse> GetResourceUses(int productId);

    }
}
