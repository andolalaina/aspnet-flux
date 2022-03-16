using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using GestionFlux.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Services
{
    public class MessageService : IMessageService
    {
        private Repository<Request> requestRepository;
        private Repository<Notification> notificationRepository;

        public MessageService(Repository<Request> requestRepo, Repository<Notification> notificationRepo)
        {
            this.requestRepository = requestRepo;
            this.notificationRepository = notificationRepo;
        }
        public IEnumerable<Request> GetRequests(int? senderId = 0, int? sentToId = 0)
        {
            IEnumerable<Request> requests = requestRepository.GetAll();
            if (senderId != 0) requests = requests.Where(x => x.Sender.Id.Equals(senderId));
            if (sentToId != 0) requests = requests.Where(x => x.SendTo.Id.Equals(sentToId));
            return requests;
        }
        public Request GetRequest(int id)
        {
            return requestRepository.Get(id);
        }
        public void InsertRequest(Request request)
        {
            requestRepository.Insert(request);
        }

        public IEnumerable<Notification> GetNotifications(int sentToId)
        {
            return notificationRepository.GetAll().Where(x => x.SendTo.Id.Equals(sentToId));
        }

        public Notification GetNotification(int id)
        {
            return notificationRepository.Get(id);
        }

        public void InsertNotification(Notification notification)
        {
            notificationRepository.Insert(notification);
        }
    }
}
