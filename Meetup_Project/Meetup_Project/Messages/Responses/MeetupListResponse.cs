using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup_Project.Messages.Responses
{
    public class MeetupListResponse {
             public int Id { get; }
             public string Name { get; }
             public string Organizer { get; }
             public DateTime Date { get; }
             public bool IsPrivate { get; }
             public string City { get; }
     
             public MeetupListResponse(int id, string name, string organizer, DateTime date, bool isPrivate, string city)
             {
                 Id = id;
                 Name = name;
                 Organizer = organizer;
                 Date = date;
                 IsPrivate = isPrivate;
                 City = city;
             }
    }
}
