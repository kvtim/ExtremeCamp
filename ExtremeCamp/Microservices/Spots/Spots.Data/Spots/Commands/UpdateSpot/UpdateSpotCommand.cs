using MediatR;
using Spots.Core.Dtos.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Commands.UpdateSpot
{
    public class UpdateSpotCommand : IRequest<SpotDto>
    {
        public int Id { get; set; }
        public UpdateSpotDto UpdateSpotDto { get; set; }
    }
}
