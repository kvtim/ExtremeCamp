using AutoMapper;
using Meetups.Core.Dtos.Meetup;
using Meetups.Core.Dtos.Participant;
using Meetups.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Api.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Meetup, MeetupDto>().ReverseMap();
            CreateMap<Meetup, CreateMeetupDto>().ReverseMap();
            CreateMap<Meetup, UpdateMeetupDto>().ReverseMap();

            CreateMap<Participant, ParticipantDto>().ReverseMap();
            CreateMap<Participant, AddParticipantDto>().ReverseMap();
        }
    }
}
