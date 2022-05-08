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
        IEnumerable<Equipment> GetEquipments();
        IEnumerable<Resource> GetResources();
        void AddEquipmentUse();
        void AddResourceUse();

    }
}
