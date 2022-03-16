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
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Département")]
        public string Department { get; set; }
    }
}