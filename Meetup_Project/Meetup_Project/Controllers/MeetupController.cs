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
            if (meetup == null)
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
        public async Task<ActionResult> Post([FromBody] MeetupRequest request)
        {
            var meetup = new Meetup
            {
                Location = new Localization(),
            };

            MapPropsToRecord(meetup, request);
            AddLectures(meetup, request?.Lectures);

            _meetupContex.Meetups.Add(meetup);
            await _meetupContex.SaveChangesAsync();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MeetupRequest request)
        {
            var meetup = await _meetupContex.Meetups
                .Include(x => x.Location)
                .Include(x => x.Lectures)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (meetup == null)
            {
                return BadRequest();
            }

            MapPropsToRecord(meetup, request);
            RemoveLectures(meetup, request.Lectures);
            AddLectures(meetup, request.Lectures);

            await _meetupContex.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var meetup = await _meetupContex.Meetups
                .Include(m => m.Location)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (meetup == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        private void MapPropsToRecord(Meetup record, MeetupRequest request)
        {
            record.Name = request.Name;
            record.Date = request.Date;
            record.Organizer = request.Organizer;
            record.IsPrivate = request.IsPrivate;
            record.Location.City = request.City;
            record.Location.Street = request.Street;
            record.Location.PostCode = request.PostalCode;
        }

        private void AddLectures(Meetup record, ICollection<LectureDto> lectures)
        {
            foreach (var lecture in lectures)
            {
                record.Lectures.Add(new Lectures(lecture.Author, lecture.Topic, lecture.Description));
            }
        }

        private void RemoveLectures(Meetup record, ICollection<LectureDto> lectures)
        {
            var recordToRemove = record.Lectures
                .Where(x => !lectures.Select(y => y.Id).Contains(x.Id))
                .ToList();
            recordToRemove.ForEach(x => record.Lectures.Remove(x));
        }
    }
}