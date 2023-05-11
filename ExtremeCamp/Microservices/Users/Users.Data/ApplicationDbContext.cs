using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Models;
using Users.Data.Configuration;
using Users.Data.Seed;

namespace Users.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Seed();
        }
    }
}
