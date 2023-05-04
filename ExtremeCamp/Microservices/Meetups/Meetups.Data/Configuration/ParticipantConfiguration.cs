using Meetups.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetups.Data.Configuration
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasOne<Meetup>(p => p.Meetup)
                .WithMany(m => m.Participants)
                .HasForeignKey(p => p.MeetupId);
        }
    }
}
