using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup_Project.Entities
{
    public class Meetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; }
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }
        public virtual ICollection<Lectures> Lectures { get; set; } = new List<Lectures>();
        public virtual Localization Location { get; set; }

        public Meetup()
        {
            
        }

        public Meetup(string name, string organizer, DateTime date, bool isPrivate)
        {
            Name = name;
            Organizer = organizer;
            Date = date;
            IsPrivate = isPrivate;
        }
    }
}
