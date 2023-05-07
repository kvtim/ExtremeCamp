using MediatR;
using Meetups.Core.Dtos.Meetup;
using Meetups.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommand : IRequest<MeetupDto>
    {
        public Meetup Meetup { get; set; }
    }
}
