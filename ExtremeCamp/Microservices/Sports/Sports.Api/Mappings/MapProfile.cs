using AutoMapper;
using Sports.Core.Dtos.Sport;
using Sports.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Api.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Sport, SportDto>().ReverseMap();
            CreateMap<Sport, CreateSportDto>().ReverseMap();
            CreateMap<Sport, UpdateSportDto>().ReverseMap();
        }
    }
}
