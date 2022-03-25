using GestionFlux.Service.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionFlux.API.Controllers
{
    public class ClientsController : ApiController
    {
        private IMarketingService marketingService;
        public ClientsController(IMarketingService marketingService)
        {
            this.marketingService = marketingService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(marketingService.GetClients());
        }
    }
}
