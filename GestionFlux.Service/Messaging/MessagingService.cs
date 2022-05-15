using GestionFlux.Core.Repository;
using GestionFlux.Core.Service;
using GestionFlux.Domain.Interfaces;
using GestionFlux.Domain.Models;
using GestionFlux.Domain;
using GestionFlux.Repository;
using GestionFlux.Service.Messaging;
using System.Collections.Generic;
using System.Linq;
using GestionFlux.Repository.User;
using GestionFlux.Repository.Request;

namespace GestionFlux.Service.Messaging
{
    public class MessagingService : IMessagingService
    {
        private IRequestRepository<Request, FluxDbContext> _requestRepository;
        private IRepository<Notification, FluxDbContext> _notificationRepository;
        private IUserRepository<User, FluxDbContext> _userRepository;

        public MessagingService(IRequestRepository<Request, FluxDbContext> requestRepo, IRepository<Notification, FluxDbContext> notificationRepo, IUserRepository<User, FluxDbContext> userRepo)
        {
            _requestRepository = requestRepo;
            _notificationRepository = notificationRepo;
            _userRepository = userRepo;
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
        public void InsertRequest(MessagingViewModels.RequestViewModels request)
        {
            _requestRepository.sendRequest(request.Message, request.SenderId, request.SendToId);
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
