using GestionFlux.Service.Interfaces;
using GestionFlux.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionFlux.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List < UserViewModel> model = new List<UserViewModel>();
            userService.GetUsers().ToList().ForEach(u =>
            {
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                };
                model.Add(user);
            });

            return View(model);
        }
    }
}