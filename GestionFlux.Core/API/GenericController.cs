using GestionFlux.Core.Domain;
using GestionFlux.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GestionFlux.Core.API
{
    public class GenericController<TService, TEntity> : ApiController 
        where TService : IService<TEntity>
        where TEntity : BaseEntity
    {
        protected TService _service;
        public GenericController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetOne(int id)
        {
            return Ok(_service.GetOne(id));
        }

        [HttpPost]
        public IHttpActionResult Insert(TEntity entity)
        {
            _service.InsertOne(entity);
            return Ok(entity);
        }

        [HttpPatch]
        public IHttpActionResult update(TEntity entity)
        {
            _service.UpdateOne(entity);
            return Ok(entity);
        }

        [HttpDelete]
        public IHttpActionResult delete(TEntity entity)
        {
            _service.DeleteOne(entity);
            return Ok();
        }
    }
}
