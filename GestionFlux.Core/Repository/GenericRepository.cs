using GestionFlux.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Core.Repository
{
    public class GenericRepository<TEntity, TContext> : IRepository<TEntity, TContext> 
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

        public void Update(int id, TEntity entity)
        {
            TEntity updated = _entities.First(s => s.Id == id);
            foreach (var x in typeof(TEntity).GetProperties())
                if (x.Name != "Id")
                    x.SetValue(updated, x.GetValue(entity));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entity = _entities.SingleOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
