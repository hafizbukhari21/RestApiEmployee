using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/baseController/[controller]")]
    [ApiController]
    public class BaseController<Entity,Repository,Key> : ControllerBase
        where Entity :class
        where Repository : IRepository<Entity,Key>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            return Ok(repository.get());
        }

        [HttpPost]
        public ActionResult<Entity> post(Entity entity)
        {
            return Ok(repository.Insert(entity));
        }

        [HttpPatch]
        public ActionResult<Entity> Update(Entity entity)
        {
            return Ok(repository.Update(entity));
        }

        [HttpDelete]
        public ActionResult<Entity> Delete(Key key)
        {
            return Ok(repository.Delete(key));
        }


    }
}
