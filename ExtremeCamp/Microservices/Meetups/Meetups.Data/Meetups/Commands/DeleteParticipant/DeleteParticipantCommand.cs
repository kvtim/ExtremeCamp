using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Commands.DeleteParticipant
{
    public class DeleteParticipantCommand : IRequest<Unit>
    {
        public int MeetupId { get; set; }
        public int UserId { get; set; }

        public int CurrentUserId { get; set; }
        public string Role { get; set; }
    }
}
