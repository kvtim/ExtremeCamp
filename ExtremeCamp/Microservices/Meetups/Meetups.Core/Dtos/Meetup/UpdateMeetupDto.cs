using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Core.Dtos.Meetup
{
    public class UpdateMeetupDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Sport { get; set; }
        public string? Address { get; set; }
        public DateTime MeetupDate { get; set; }
    }
}
