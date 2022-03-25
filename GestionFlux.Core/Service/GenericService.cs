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
    public class GenericService<TEntity> : IService<TEntity>
        where TEntity : BaseEntity
    {
        protected GenericRepository<TEntity, DbContext> _repository;

        public GenericService(GenericRepository<TEntity, DbContext> genericRepository)
        {
            _repository = genericRepository;
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

        public void UpdateOne(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void DeleteOne(TEntity entity)
        {
            _repository.Delete(entity);
        }

    }
}
