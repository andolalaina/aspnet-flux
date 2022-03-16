using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionFlux.API.ViewModels
{
    public class RequestViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }

        [Display(Name = "Sender")]
        public int SenderId { get; set; }

        [Display(Name = "SentTo")]
        public int SentToId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "SendDate")]
        public DateTime SendDate { get; set; }
    }
}