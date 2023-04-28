using AutoMapper;
using Spots.Core.Dtos.Spot;
using Spots.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Api.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Spot, SpotDto>().ReverseMap();
            CreateMap<Spot, CreateSpotDto>().ReverseMap();
            CreateMap<Spot, UpdateSpotDto>().ReverseMap();
        }
    }
}
