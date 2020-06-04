using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetup_Project.Entities;
using Meetup_Project.Messages.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        
        
         [HttpGet]
                public async Task<List<MeetupListResponse>> Get()
                {
                    return await _meetupContex.Meetups
                        .Include(m => m.Location)
                        .Select(x => new MeetupListResponse(x.Id,
                            x.Name,
                            x.Organizer,
                            x.Date,
                            x.IsPrivate,
                            x.Location.City))
                        .ToListAsync();
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
