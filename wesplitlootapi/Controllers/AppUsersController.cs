using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace wesplitlootapi.Controllers
{
    // this is old -> but represents CRUD on object in mongodb
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        // GET api/appusers
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/appusers/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/appusers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/appusers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/appusers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
