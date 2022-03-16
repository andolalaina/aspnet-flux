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
        public IHttpActionResult Get()
        {
            return Ok(messageService.GetRequests());
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] int userId)
        {
            return Ok(messageService.GetSenderRequests(userId));
        }
    }
}
