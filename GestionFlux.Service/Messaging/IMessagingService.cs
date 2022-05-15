using GestionFlux.Core.Service;
using GestionFlux.Domain.Models;
using GestionFlux.Domain.Interfaces;
using GestionFlux.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Messaging
{
    public interface IMessagingService
    {
        IEnumerable<Request> GetRequests(int? senderId = 0, int? sentToId = 0);
        Request GetRequest(int id);
        void InsertRequest(MessagingViewModels.RequestViewModels request);

        IEnumerable<Notification> GetNotifications(int sentToId);
        Notification GetNotification(int id);
        void InsertNotification(Notification notification);
    }
}
