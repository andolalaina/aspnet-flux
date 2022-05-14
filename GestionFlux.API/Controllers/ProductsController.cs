using GestionFlux.Domain.Models;
using GestionFlux.Service.Marketing;
using GestionFlux.Service.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionFlux.API.Controllers
{
    public class ProductsController : ApiController
    {
        private IMarketingService _marketingService;
        private IProductionService _productionService;
        public ProductsController(IMarketingService marketingService, IProductionService productionService)
        {
            this._marketingService = marketingService;
            this._productionService = productionService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_marketingService.GetProducts());
        }
        [HttpGet]
        [Route("api/products/processes")]
        public IHttpActionResult GetProcesses()
        {
            return Ok(_productionService.GetProductionProcesses());
        }
        [HttpPost]
        [Route("api/products/equipment-use")]
        public IHttpActionResult AddEquipmentUse([FromBody] ProductionViewModels.ProductEquipmentUseDetail useDetail)
        {
            _productionService.AddProductEquipmentUse(useDetail.ProductId, useDetail.EquipmentId, useDetail.UseDegradation, useDetail.UseDuration);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update([FromBody] Product p)
        {
            _marketingService.UpdateProduct(p);
            return Ok();
        }
        [HttpPut]
        [Route("api/products/processes")]
        public IHttpActionResult UpdateProcess([FromBody] ProductionViewModels.ProductionProcessDetail processDetail)
        {
            System.Diagnostics.Debug.WriteLine("Niantso...");
            _productionService.updateProductionProcess(processDetail.Id, processDetail);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int productId)
        {
            _marketingService.DeleteProduct(productId);
            return Ok();
        }
    }
}
