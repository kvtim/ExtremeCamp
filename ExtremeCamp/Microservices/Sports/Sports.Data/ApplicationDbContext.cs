using Microsoft.EntityFrameworkCore;
using Sports.Core.Models;
using Sports.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Sport> Sports { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SportConfiguration());
        }
    }
}
