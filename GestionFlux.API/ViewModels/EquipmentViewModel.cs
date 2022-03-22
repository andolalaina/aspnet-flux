using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionFlux.API.ViewModels
{
    public class EquipmentViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }

        public string Ref { get; set; }
        public string Name { get; set; }
        public int Usability { get; set; }
        public int InStock { get; set; }
    }
}