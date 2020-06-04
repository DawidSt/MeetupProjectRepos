using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetup_Project.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Meetup_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        private readonly MeetupContex _meetupContex;

        public MeetupController(MeetupContex meetupContex)
        {
            _meetupContex = meetupContex;
        }
        
        
        
        
        
        
        
        
        

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
