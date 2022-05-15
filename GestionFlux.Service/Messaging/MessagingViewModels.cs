using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Messaging
{
    public class MessagingViewModels
    {
        public class RequestViewModels
        {
            public int SenderId { get; set; }
            public int SendToId { get; set; }
            public string Message { get; set; }
        }
    }
}
