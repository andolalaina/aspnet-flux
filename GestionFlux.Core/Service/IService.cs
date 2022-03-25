using GestionFlux.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Core.Service
{
    public interface IService<TEntity, TContext>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetOne(int id);
        void InsertOne(TEntity entity);
        void UpdateOne(int id, TEntity entity);
        void DeleteOne(int id);
    }
}
