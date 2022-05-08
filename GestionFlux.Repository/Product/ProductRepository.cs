using GestionFlux.Domain;
using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.Product
{
    public class ProductRepository<TEntity, TContext> : BaseRepository<TEntity, TContext>, IProductRepository<TEntity, TContext>
        where TEntity: Domain.Models.Product
        where TContext: FluxDbContext
    {
        public ProductRepository(TContext context) : base(context) { }

        public void AddEquipmentUse()
        {
            throw new NotImplementedException();
        }

        public void AddResourceUse()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> GetEquipments(Domain.Models.Product product)
        {
            throw new NotImplementedException();
            //return _context.Equipments.Where((equipment) => equipment.EquipmentUse.Product == product);
        }

        public IEnumerable<Resource> GetResources()
        {
            throw new NotImplementedException();
        }
    }
}
