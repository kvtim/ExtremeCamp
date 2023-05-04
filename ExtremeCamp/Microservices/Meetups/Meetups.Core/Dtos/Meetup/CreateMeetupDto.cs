using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Core.Dtos.Meetup
{
    public class CreateMeetupDto
    {
        public required string? Title { get; set; }
        public required string? Description { get; set; }
        public required string? Sport { get; set; }
        public required string? Address { get; set; }

        public required DateTime MeetupDate { get; set; }

        public required int OwnerId { get; set; }
    }
}
