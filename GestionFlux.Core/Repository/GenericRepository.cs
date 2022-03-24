using GestionFlux.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Core.Repository
{
    public class GenericRepository<TEntity> : 
        IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext context;
        private DbSet<TEntity> entities;
        string errorMessage = string.Empty;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return entities.AsEnumerable();
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
