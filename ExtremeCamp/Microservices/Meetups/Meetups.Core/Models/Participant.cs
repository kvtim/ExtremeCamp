using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Core.Models
{
    public class Participant
    {
        public int Id { get; set; }

        public int MeetupId { get; set; }
        public Meetup Meetup { get; set; }

        public int UserId { get; set; }
    }
}
