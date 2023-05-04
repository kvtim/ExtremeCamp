using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Core.Dtos.Participant
{
    public class DeleteParticipantDto
    {
        public required int MeetupId { get; set; }
        public required int UserId { get; set; }
    }
}
