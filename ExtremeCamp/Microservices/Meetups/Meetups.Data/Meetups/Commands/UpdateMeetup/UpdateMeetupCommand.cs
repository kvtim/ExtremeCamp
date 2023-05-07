using MediatR;
using Meetups.Core.Dtos.Meetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommand : IRequest<MeetupDto>
    {
        public int Id { get; set; }
        public UpdateMeetupDto UpdateMeetupDto { get; set; }

        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
