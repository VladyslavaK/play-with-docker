using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Infrastructure;

namespace SimpleAPI.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/ToDo")]
    public class ToDoController : Controller
    {
        private Repository _repo;

        public ToDoController(Repository repo)
        {
            _repo = repo;
        }

        // GET: api/ToDo
        [HttpGet]
        public IEnumerable<ToDoTask> Get()
        {
            return _repo.GetTasks();
        }

            
        // POST: api/ToDo
        [HttpPost]
        public long Post([FromBody]ToDoTask value)
        {
            return _repo.AddTask(value);
        }
        
        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
