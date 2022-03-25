using GestionFlux.Service.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionFlux.API.Controllers
{
    public class DepartmentsController : ApiController
    {
        private IAuthService userService;

        public DepartmentsController(IAuthService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(userService.GetDepartments());
        }
    }
}
