using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup_Project.Entities
{
    public class Lectures
    {

        public int Id { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public virtual Meetup Meetup { get; set; }
        public int MeetupId { get; set; }

        public Lectures()
        {
            
        }

        public Lectures(int id, string author, string topic, string description, Meetup meetup, int meetupId)
        {
            Id = id;
            Author = author;
            Topic = topic;
            Description = description;
            Meetup = meetup;
            MeetupId = meetupId;
        }
    }
}
