using MediatR;
using Meetups.Core.Dtos.Meetup;
using Meetups.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Commands.AddParticipant
{
    public class AddParticipantCommand : IRequest<MeetupDto>
    {
        public Participant Participant { get; set; }
    }
}
