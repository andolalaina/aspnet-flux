using GestionFlux.API.ViewModels;
using GestionFlux.Domain.Models;
using GestionFlux.Service.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionFlux.API.Controllers
{
    public class UsersController : ApiController
    {
        private IAuthService userService;
        public UsersController(IAuthService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(userService.GetUsers());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(userService.GetUser(id));
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] UserViewModel model)
        {
            User userEntity = new User
            {
                Username = model.Username,
                Password = model.Password.GetHashCode(),
                Matricule = model.Matricule,
                Department = new Department
                {
                    Name = model.Department
                }
            };
            userService.InsertUser(userEntity);
            if (!(userEntity.Id > 0))
            {
                return BadRequest();
            }
            return Ok(userEntity);
        }

        [HttpPost]
        [Route("api/users/authenticate")]
        public IHttpActionResult Authenticate([FromBody] UserAuthenticationViewModel credential)
        {
            User authenticatedUser = userService.Authenticate(credential.Username, credential.Password);
            System.Diagnostics.Debug.WriteLine(authenticatedUser);
            if (authenticatedUser == null) return BadRequest("Aucun utilisateur associé");
            return Ok(authenticatedUser);
        }
    }
}
