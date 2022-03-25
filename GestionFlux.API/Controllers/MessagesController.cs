using GestionFlux.API.ViewModels;
using GestionFlux.Domain.Models;
using GestionFlux.Service.Messaging;
using GestionFlux.Service.Auth;
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
        private IMessagingService messageService;
        private IAuthService userService;

        public MessagesController(IMessagingService messageService, IAuthService userService)
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

        [HttpPost]
        [Route("api/requests")]
        public IHttpActionResult Create([FromBody] RequestViewModel model)
        {
            try
            {
                Request request = new Request
                {
                    Sender = userService.GetUser(model.SenderId),
                    SendTo = userService.GetUser(model.SentToId),
                    SendDate = DateTime.Now,
                    Description = model.Description
                };
                return Ok(request);
            } catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
