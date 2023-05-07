using Microsoft.EntityFrameworkCore;
using Meetups.Core.Models;
using Meetups.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MeetupConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
        }
    }
}
