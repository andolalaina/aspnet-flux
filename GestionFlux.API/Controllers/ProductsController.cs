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
        private SMA.Agents.Marketing _marketingAgent;
        public ProductsController(IMarketingService marketingService, IProductionService productionService, SMA.Agents.Marketing marketingAgent)
        {
            this._marketingService = marketingService;
            this._productionService = productionService;
            _marketingAgent = marketingAgent;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_marketingAgent.GetSuggProducts());
        }

        [HttpGet]
        public IHttpActionResult GetProductDetail([FromUri] int productId)
        {
            return Ok(_marketingAgent.GetSuggProduct(productId));
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
