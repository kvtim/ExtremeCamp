using AutoMapper;
using MediatR;
using Spots.Core.Dtos.Spot;
using Spots.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Commands.CreateSpot
{
    public class CreateSpotCommandHandler : IRequestHandler<CreateSpotCommand, SpotDto>
    {
        private readonly ISpotRepository _repository;
        private readonly IMapper _mapper;

        public CreateSpotCommandHandler(ISpotRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SpotDto> Handle(CreateSpotCommand request, CancellationToken cancellationToken)
        {
            var spot = await _repository.GetSpotByNameAsync(request.Spot.Name);

            if (spot != null)
            {
                throw new ArgumentException("Spot already exists!");
            }

            await _repository.AddAsync(request.Spot);
            await _repository.SaveChangesAsync();

            return _mapper.Map<SpotDto>(request.Spot);
        }
    }
}
