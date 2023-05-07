using AutoMapper;
using MediatR;
using Spots.Core.Dtos.Spot;
using Spots.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Commands.UpdateSpot
{
    public class UpdateSpotCommandHandler : IRequestHandler<UpdateSpotCommand, SpotDto>
    {
        ISpotRepository _repository;
        IMapper _mapper;

        public UpdateSpotCommandHandler(ISpotRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SpotDto> Handle(UpdateSpotCommand request, CancellationToken cancellationToken)
        {
            var spot = await _repository.GetByIdAsync(request.Id);

            if (spot == null)
            {
                throw new KeyNotFoundException("Spot doesn't exist!");
            }

            spot.Name = request.UpdateSpotDto.Name;
            spot.Description = request.UpdateSpotDto.Description;
            spot.Location = request.UpdateSpotDto.Location;

            await _repository.UpdateAsync(spot);
            await _repository.SaveChangesAsync();

            return _mapper.Map<SpotDto>(spot);
        }
    }
}
