using GestionFlux.Service.Logistic;
using GestionFlux.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionFlux.Domain.Models;

namespace GestionFlux.API.Controllers
{
    public class EquipmentsController : ApiController
    {
        private ILogisticService equipmentService;

        public EquipmentsController(ILogisticService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(this.equipmentService.GetEquipments());
        }

        [HttpPost]
        public IHttpActionResult Add(EquipmentViewModel equipmentViewModel)
        {
            Equipment equipment = new Equipment
            {
                Name = equipmentViewModel.Name,
                Usability = equipmentViewModel.Usability,
                Ref = equipmentViewModel.Ref,
                InStock = equipmentViewModel.InStock
            };
            equipmentService.AddEquipment(equipment);
            return Ok(this.equipmentService.GetEquipments());
        }
    }
}
