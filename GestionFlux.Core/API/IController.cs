using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GestionFlux.Core.API
{
    public interface IController<TEntity, TContext>
    {
        [HttpGet]
        IHttpActionResult Get();

        [HttpGet]
        IHttpActionResult GetOne(int id);

        [HttpPost]
        IHttpActionResult Insert(TEntity entity);

        [HttpPut]
        IHttpActionResult Update(int id, TEntity entity);

        [HttpDelete]
        IHttpActionResult Delete(int id);
    }
}
