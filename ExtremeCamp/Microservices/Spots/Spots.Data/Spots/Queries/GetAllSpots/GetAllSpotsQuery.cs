using MediatR;
using Spots.Core.Dtos.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Queries.GetAllSpots
{
    public class GetAllSpotsQuery : IRequest<IEnumerable<SpotDto>>
    {
    }
}
