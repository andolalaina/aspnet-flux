using GestionFlux.Core.Repository;
using GestionFlux.Core.Service;
using GestionFlux.Domain.Interfaces;
using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using GestionFlux.Service.Messaging;
using System.Collections.Generic;
using System.Linq;

namespace GestionFlux.Service.Messaging
{
    public class MessagingService : IMessagingService
    {
        private BaseRepository<Request, FluxDbContext> _requestRepository;
        private BaseRepository<Notification, FluxDbContext> _notificationRepository;

        public MessagingService(BaseRepository<Request, FluxDbContext> requestRepo, BaseRepository<Notification, FluxDbContext> notificationRepo)
        {
            _requestRepository = requestRepo;
            _notificationRepository = notificationRepo;
        }
        public IEnumerable<Request> GetRequests(int? senderId = 0, int? sentToId = 0)
        {
            IEnumerable<Request> requests = _requestRepository.GetAll();
            if (senderId != 0) requests = requests.Where(x => x.Sender.Id.Equals(senderId));
            if (sentToId != 0) requests = requests.Where(x => x.SendTo.Id.Equals(sentToId));
            return requests;
        }
        public Request GetRequest(int id)
        {
            return _requestRepository.Get(id);
        }
        public void InsertRequest(Request request)
        {
            _requestRepository.Insert(request);
        }

        public IEnumerable<Notification> GetNotifications(int sentToId)
        {
            return _notificationRepository.GetAll().Where(x => x.SendTo.Id.Equals(sentToId));
        }

        public Notification GetNotification(int id)
        {
            return _notificationRepository.Get(id);
        }

        public void InsertNotification(Notification notification)
        {
            _notificationRepository.Insert(notification);
        }
    }
}
