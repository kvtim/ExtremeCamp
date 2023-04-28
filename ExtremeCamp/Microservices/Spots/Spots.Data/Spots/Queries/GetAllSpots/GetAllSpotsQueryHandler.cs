using AutoMapper;
using MediatR;
using Spots.Core.Dtos.Spot;
using Spots.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Queries.GetAllSpots
{
    public class GetAllSpotsQueryHandler : IRequestHandler<GetAllSpotsQuery, IEnumerable<SpotDto>>
    {
        ISpotRepository _repository;
        IMapper _mapper;

        public GetAllSpotsQueryHandler(ISpotRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpotDto>> Handle(GetAllSpotsQuery request, CancellationToken cancellationToken)
        {
            var spots = await _repository.GetAllAsync();

            if (!spots.Any())
            {
                throw new Exception("Spots don't exist!");
            }

            return _mapper.Map<IEnumerable<SpotDto>>(spots);
        }
    }
}
