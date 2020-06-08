using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetup_Project.Messages;
using Meetup_Project.Messages.Requests;
using Meetup_Project.Messages.Responses;
using Meetup_Project.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Meetup_Project.Controllers
{
    [Route("api/[meetup]")]
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
        public async Task<ActionResult<MeetupDetailsResponse>> Get(int id)
        {
            var meetup = await _meetupContex.Meetups
                .Include(m => m.Location)
                .Include(x => x.Lectures)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (meetup==null)
            {
                return NotFound();
            }
            return new MeetupDetailsResponse(meetup.Name,
                meetup.Organizer,
                meetup.Date,
                meetup.IsPrivate,
                meetup.Location?.City,
                meetup.Location?.Street,
                meetup.Location?.PostCode,
                meetup.Lectures?.Select(x => new MeetupDetailsResponse.LecturesDto(x.Id,
                    x.Author,
                    x.Topic,
                    x.Description))
                .ToList());
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MeeetupRequest request)
        {
            var meetup = new Meetup
            {
                Location = new Localization(),
        };
            


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
