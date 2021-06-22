using API52.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API52.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity,Repository,Key> : ControllerBase 
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var get = repository.Get();
            return Ok(new { status = HttpStatusCode.OK, result = get, messasge = "Success" });
        }

        [HttpGet("{key}")]
        public ActionResult Find(Key key)
        {
            var response = repository.Get(key);
            if (key == null)
            {
                var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
                return get;
            }
            else
            {
                var get = Ok(new { status = HttpStatusCode.OK, result = response, messasge = "Success" });
                return get;
            }
        }
        [HttpPost]
        public ActionResult Post(Entity e)
        {
            var insert = repository.Insert(e);
            if (insert == 1)
            {
                var get = Ok(new { status = HttpStatusCode.OK, result = insert, messasge = "Success" });
                return get;
            }
            else
            {
                var get = NotFound(new { status = HttpStatusCode.NotFound, result = insert, messasge = "Not Found" });
                return get;
            }
        }
        [HttpDelete]
        public ActionResult Delete(Key key)
        {
            var response = repository.Delete(key);
            if (key == null)
            {
                var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
                return get;
            }
            else
            {
                if (response == 1)
                {
                    var get = Ok(new { status = HttpStatusCode.OK, result = response, messasge = "Success" });
                    return get;
                }
                else
                {
                    var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
                    return get;
                }
            }
        }
        [HttpPut]
        public ActionResult Update(Entity e, Key key)
        {
            var response = repository.Update(e, key);
            if (key == null)
            {
                var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
                return get;
            }
            else
            {
                if (response == 1)
                {
                    var get = Ok(new { status = HttpStatusCode.OK, result = response, messasge = "Success" });
                    return get;
                }
                else
                {
                    var get = NotFound(new { status = HttpStatusCode.NotFound, result = response, messasge = "Not Found" });
                    return get;
                }
            }
        }
    }
}
