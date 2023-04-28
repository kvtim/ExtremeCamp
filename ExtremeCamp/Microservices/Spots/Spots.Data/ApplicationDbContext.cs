using Microsoft.EntityFrameworkCore;
using Spots.Core.Models;
using Spots.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Spot> Spots { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpotConfiguration());
        }
    }
}
