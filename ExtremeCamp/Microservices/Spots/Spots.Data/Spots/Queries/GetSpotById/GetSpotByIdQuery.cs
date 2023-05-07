using MediatR;
using Spots.Core.Dtos.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Queries.GetSpotById
{
    public class GetSpotByIdQuery : IRequest<SpotDto>
    {
        public int Id { get; set; }
    }
}
