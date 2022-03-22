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

        public int SenderId { get; set; }

        public int SentToId { get; set; }

        public string Description { get; set; }

        public DateTime SendDate { get; set; }
    }
}