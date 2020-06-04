using Meetup_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetup_Project
{
    public class MeetupSeeder
    {
        private readonly MeetupContex _meetupContex;
        public MeetupSeeder(MeetupContex meetupContex)
        {
            _meetupContex = meetupContex;
        }

        public void Seed()
        {
            if (_meetupContex.Database.CanConnect())
            {
                if (!_meetupContex.Meetups.Any())
                {
                    InsertSampleData();
                }
            }
        }

        private void InsertSampleData()
        {
            var meetups = new List<Meetup>
            {
                new Meetup
                {
                    Name = "Web summit",
                    Date = DateTime.Now.AddDays(7),
                    IsPrivate = false,
                    Organizer = "Microsoft",
                    Location = new Localization
                    {
                        City = "Kraków",
                        Street = "Szeroka 33",
                        PostCode = "31-337"
                    },
                    Lectures = new List<Lectures>
                    {
                         new Lectures
                         {
                             Author = "Bob Clark",
                             Topic = "Modern browers",
                             Description = "Deep dive into V8"
                         }
                    }

                },
                new Meetup
                {
                    Name = "4Devs",
                    Date = DateTime.Now.AddDays(7),
                    IsPrivate = false,
                    Organizer = "KGD",
                    Location = new Localization
                    {
                         City = "Warszawa",
                         Street = "Chmielna 33",
                         PostCode = "00-007"
                    },
                    Lectures = new List<Lectures>
                    {
                        new Lectures
                        {
                            Author = "Will Smith",
                            Topic = "React.js",
                            Description = "Redux introduction"
                        },
                        new Lectures
                        {
                            Author = "John Cenah",
                            Topic = "Angular Store",
                            Description = "Ngxs in practice"
                        }
                    }



                }
            };

            _meetupContex.AddRange(meetups);
            _meetupContex.SaveChanges();
        }
    }
}