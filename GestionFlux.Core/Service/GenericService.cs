using GestionFlux.Core.Domain;
using GestionFlux.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Core.Service
{
    public class GenericService<TEntity, TContext> : IService<TEntity, TContext>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        protected IRepository<TEntity, TContext> _repository;

        public GenericService(IRepository<TEntity, TContext> repository)
        {
            _repository = repository;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetOne(int id)
        {
            return _repository.Get(id);
        }

        public void InsertOne(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public void UpdateOne(int id, TEntity entity)
        {
            _repository.Update(id, entity);
        }

        public void DeleteOne(int id)
        {
            _repository.Delete(id);
        }

    }
}
