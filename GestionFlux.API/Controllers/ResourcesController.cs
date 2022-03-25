using GestionFlux.Core.API;
using GestionFlux.Core.Service;
using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionFlux.API.Controllers
{
    public class ResourcesController : GenericController<Resource, FluxDbContext>
    {
        public ResourcesController(IService<Resource, FluxDbContext> service) : base(service)
        {

        }
    }
}
