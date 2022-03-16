using GestionFlux.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionFlux.API.Controllers
{
    public class MessagesController : ApiController
    {
        private IMessageService messageService;
        private IUserService userService;

        public MessagesController(IMessageService messageService, IUserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("api/requests")]
        public IHttpActionResult Get([FromUri] int sender = 0, [FromUri] int sentTo = 0)
        {
            return Ok(messageService.GetRequests(sender, sentTo));
        }

        [HttpGet]
        [Route("api/requests/{requestId}")]
        public IHttpActionResult Get(int requestId)
        {
            if (messageService.GetRequest(requestId) == null) return NotFound();
            return Ok(messageService.GetRequest(requestId));
        }
    }
}
