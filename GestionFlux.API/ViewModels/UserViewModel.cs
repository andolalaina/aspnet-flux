using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionFlux.API.ViewModels
{
    public class UserViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Matricule { get; set; }
        public string Department { get; set; }
    }

    public class UserAuthenticationViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}