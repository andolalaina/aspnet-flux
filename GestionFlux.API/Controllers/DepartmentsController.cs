using GestionFlux.Service.Interfaces;
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
        private IUserService userService;

        public DepartmentsController(IUserService userService)
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
