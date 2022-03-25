using GestionFlux.Core.Domain;
using GestionFlux.Core.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GestionFlux.Core.API
{
    public abstract class GenericController<TEntity, TContext> :
        ApiController, IController<TEntity, TContext>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        protected IService<TEntity, TContext> _service;
        public GenericController(IService<TEntity, TContext> service)
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
        public IHttpActionResult Insert([FromBody] TEntity entity)
        {
            _service.InsertOne(entity);
            return Ok(entity);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] TEntity entity)
        {
            _service.UpdateOne(id, entity);
            return Ok(entity);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _service.DeleteOne(id);
            return Ok();
        }
    }
}
