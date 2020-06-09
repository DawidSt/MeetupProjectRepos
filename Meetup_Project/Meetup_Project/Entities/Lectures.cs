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

        public Lectures( string author, string topic, string description)
        {
            
            Author = author;
            Topic = topic;
            Description = description;
           
        }

        
    }
}
