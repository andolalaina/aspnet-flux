using GestionFlux.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Core.Repository
{
    public class GenericRepository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        protected readonly TContext _context;
        protected DbSet<TEntity> _entities;

        public GenericRepository(TContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public TEntity Get(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
