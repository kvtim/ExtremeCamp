using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetups.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Configuration
{
    public class MeetupConfiguration : IEntityTypeConfiguration<Meetup>
    {
        public void Configure(EntityTypeBuilder<Meetup> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(t => t.Sport)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(t => t.Address)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(t => t.CreationDate)
                .HasDefaultValue(DateTime.Now);

            builder.Property(t => t.MeetupDate)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(t => t.OwnerId)
                .IsRequired();
        }
    }
}
