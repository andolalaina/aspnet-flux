using GestionFlux.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.Request
{
    public interface IRequestRepository<TEntity, TContext> : IRepository<TEntity, TContext>
    {
        void sendRequest(string message, int senderId, int sendToId);
    }
}
