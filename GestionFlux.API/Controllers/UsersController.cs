using GestionFlux.API.ViewModels;
using GestionFlux.Domain.Models;
using GestionFlux.Service.Interfaces;
using GestionFlux.Service.Services;
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
        private IUserService userService;
        public UsersController(IUserService userService)
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
                Name = model.Name,
                Email = model.Email,
                department = new Department
                {
                    Name = model.Department
                }
            };
            userService.InsertUser(userEntity);
            if (!(userEntity.Id > 0))
            {
                return BadRequest();
            }
            return Ok(model);
        }
    }
}
