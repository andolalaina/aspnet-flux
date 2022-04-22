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
        private IAuthService _authService;
        public UsersController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_authService.GetUsers());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_authService.GetUser(id));
        }

        [HttpPost]
        public IHttpActionResult Register([FromBody] AuthViewModels.UserRegister model)
        {
            if (!(model.isValid()))
            {
                return BadRequest("Le modèle n'est pas valide");
            }
            User userEntity = _authService.RegisterUser(model);
            return Ok(userEntity);
        }

        [HttpPost]
        [Route("api/users/authenticate")]
        public IHttpActionResult Authenticate([FromBody] AuthViewModels.UserLogin user)
        {
            User authenticatedUser = _authService.Authenticate(user);
            if (authenticatedUser == null) return BadRequest("Aucun utilisateur associé");
            return Ok(authenticatedUser);
        }
    }
}
