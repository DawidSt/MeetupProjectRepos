using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup_Project.Entities
{
    public class MeetupContex : DbContext
    {
        private string _connectionString = "Server=DESKTOP-MI39HGV\\SQL2017;Database=MeetupDbProject;Trusted_Connection=True;";

        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Lectures> Lectures { get; set; }
        public DbSet<Localization> Localizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

