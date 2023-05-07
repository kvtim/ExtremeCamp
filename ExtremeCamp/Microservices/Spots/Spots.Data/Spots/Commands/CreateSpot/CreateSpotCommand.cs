using MediatR;
using Spots.Core.Dtos.Spot;
using Spots.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Commands.CreateSpot
{
    public class CreateSpotCommand : IRequest<SpotDto>
    {
        public Spot Spot { get; set; }
    }
}
