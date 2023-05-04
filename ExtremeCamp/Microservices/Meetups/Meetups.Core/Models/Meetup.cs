using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Core.Models
{
    public class Meetup
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Sport { get; set; }
        public string? Address { get; set; }
        
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime MeetupDate { get; set; }

        public int OwnerId { get; set; }

        public List<Participant> Participants { get; set; } = new List<Participant>();
    }
}
