using AutoMapper;
using MediatR;
using Spots.Core.Dtos.Spot;
using Spots.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Queries.GetSpotById
{
    public class GetSpotByIdQueryHandler : IRequestHandler<GetSpotByIdQuery, SpotDto>
    {
        ISpotRepository _repository;
        IMapper _mapper;

        public GetSpotByIdQueryHandler(ISpotRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SpotDto> Handle(GetSpotByIdQuery request, CancellationToken cancellationToken)
        {
            var spot = await _repository.GetByIdAsync(request.Id);

            if (spot == null)
            {
                throw new Exception("Sport doesn't exists!");
            }

            return _mapper.Map<SpotDto>(spot);
        }
    }
}
