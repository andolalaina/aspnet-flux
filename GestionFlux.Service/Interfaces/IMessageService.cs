using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Request> GetRequests();
        IEnumerable<Request> GetRequests(User sender);
        Request GetRequest(int id);
        void InsertRequest(Request request);

        IEnumerable<Notification> GetNotifications(User sender);
        Notification GetNotification(int id);
        void InsertNotification(Notification notification);
    }
}
