using System;
using System.Collections.Generic;

namespace Meetup_Project.Messages.Responses
{
    public class MeetupDetailsResponse
    {
        public string Name { get; }
        public string Organizer { get; }
        public DateTime Date { get; }
        public bool IsPrivate { get; }
        public string City { get; }
        public string Street { get; }
        public string PostCode { get; }
        public List<LecturesDto> Lectures { get; }

        public MeetupDetailsResponse(string name, string organizer, DateTime date, bool isPrivate, string city, string street, string postCode,
            
            
            List<LecturesDto> lectures) {
            Name = name;
            Organizer = organizer;
            Date = date;
            IsPrivate = isPrivate;
            City = city;
            Street = street;
            PostCode = postCode;
            Lectures = lectures;
        }

        public class LecturesDto
        {
            public int Id { get; }
            public string Author { get; }
            public string Topic { get; }
            public string Description { get; }

            public LecturesDto(int id, string author, string topic, string description)
            {
                Id = id;
                Author = author;
                Topic = topic;
                Description = description;
            }
        }
    }
}