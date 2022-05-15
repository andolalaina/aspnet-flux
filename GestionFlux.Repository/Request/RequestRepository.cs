using GestionFlux.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Repository.Request
{
    public class RequestRepository<TEntity, TContext> : BaseRepository<TEntity, TContext>, IRequestRepository<TEntity, TContext>
        where TEntity : Domain.Models.Request
        where TContext : FluxDbContext

    {
        public RequestRepository(TContext context) : base(context) { }

        public void sendRequest(string message, int senderId, int sendToId)
        {
            Domain.Models.User sender = _context.Users.FirstOrDefault((u) => u.Id == senderId);
            Domain.Models.User sendTo = _context.Users.FirstOrDefault((u) => u.Id == sendToId);

            if (sender != null && sendTo != null)
            {
                _context.Requests.Add(new Domain.Models.Request { 
                    Sender = sender,
                    SendTo = sendTo,
                    Description = message,
                    SendDate = DateTime.Now
                });
                _context.SaveChanges();
            }
        }
    }
}
