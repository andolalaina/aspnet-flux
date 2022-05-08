using GestionFlux.Domain;
using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void AddEquipmentUse(int productId, int equipmentId, int useDegradation, int useDuration)
        {
            _context.EquipmentUses.Add(new EquipmentUse
            {
                Equipment = _context.Equipments.Find(equipmentId),
                Product = _context.Products.Find(productId),
                UseDegradation = useDegradation,
                UseDuration = useDuration
            });
            _context.SaveChanges();
        }

        public void AddResourceUse(int productId, int resourceId, int quantity)
        {
            _context.ResourceUses.Add(new ResourceUse
            {
                Product = _context.Products.Find(productId),
                Resource = _context.Resources.Find(resourceId),
                Quantity =quantity
            });
            _context.SaveChanges();
        }

        public IEnumerable<Equipment> GetEquipments(int productId)
        {
            return _context.EquipmentUses
                .Where((equipmentUse) => equipmentUse.Product.Id == productId)
                .Select((equipmentUse) => equipmentUse.Equipment);
        }

        public IEnumerable<EquipmentUse> GetEquipmentUses(int productId)
        {
            return _context.EquipmentUses.Where((use) => use.Product.Id == productId);
        }

        public IEnumerable<Resource> GetResources(int productId)
        {
            return _context.ResourceUses
                .Where((resourceUse) => resourceUse.Product.Id == productId)
                .Select((resourceUse) => resourceUse.Resource);
        }

        public IEnumerable<ResourceUse> GetResourceUses(int productId)
        {
            return _context.ResourceUses.Where((use) => use.Product.Id == productId);
        }

        public void RemoveEquipmentUse(int productId, int equipmentId)
        {
            _context.EquipmentUses.RemoveRange(
                _context.EquipmentUses.Where((use) => use.Product.Id == productId && use.Equipment.Id == equipmentId)
            );
        }

        public void RemoveResourceUse(int productId, int resourceId)
        {
            _context.ResourceUses.RemoveRange(
                _context.ResourceUses.Where((use) => use.Product.Id == productId && use.Resource.Id == resourceId)
            );
        }
    }
}
