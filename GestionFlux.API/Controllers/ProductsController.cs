﻿using GestionFlux.Domain.Models;
using GestionFlux.Service.Marketing;
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
        private IMarketingService marketingService;
        public ProductsController(IMarketingService marketingService)
        {
            this.marketingService = marketingService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(marketingService.GetProducts());
        }
        [HttpPut]
        public IHttpActionResult Update([FromBody] Product p)
        {
            marketingService.UpdateProduct(p);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int productId)
        {
            marketingService.DeleteProduct(productId);
            return Ok();
        }
    }
}
