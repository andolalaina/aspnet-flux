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
        private IMessagingService _messagingService;
        private IAuthService _userService;

        public MessagesController(IMessagingService messageService, IAuthService userService)
        {
            this._messagingService = messageService;
            this._userService = userService;
        }

        [HttpGet]
        [Route("api/requests")]
        public IHttpActionResult Get([FromUri] int sender = 0, [FromUri] int sentTo = 0)
        {
            return Ok(_messagingService.GetRequests(sender, sentTo));
        }

        [HttpGet]
        [Route("api/requests/{requestId}")]
        public IHttpActionResult Get(int requestId)
        {
            if (_messagingService.GetRequest(requestId) == null) return NotFound();
            return Ok(_messagingService.GetRequest(requestId));
        }

        [HttpPost]
        [Route("api/requests")]
        public IHttpActionResult SendRequest([FromBody] MessagingViewModels.RequestViewModels request)
        {
            _messagingService.InsertRequest(request);
            return Ok();
        }
    }
}
