using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sports.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Configuration
{
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(t => t.Season)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
