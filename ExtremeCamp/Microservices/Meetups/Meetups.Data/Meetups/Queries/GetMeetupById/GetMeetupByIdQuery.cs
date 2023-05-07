using MediatR;
using Meetups.Core.Dtos.Meetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Queries.GetMeetupById
{
    public class GetMeetupByIdQuery : IRequest<MeetupDto>
    {
        public int Id { get; set; }
    }
}
