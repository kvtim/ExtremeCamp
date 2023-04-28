using AutoMapper;
using MediatR;
using Sports.Core.Dtos.Sport;
using Sports.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Commands.UpdateSport
{
    public class UpdateSportCommandHandler : IRequestHandler<UpdateSportCommand, SportDto>
    {
        ISportRepository _repository;
        IMapper _mapper;

        public UpdateSportCommandHandler(ISportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SportDto> Handle(UpdateSportCommand request, CancellationToken cancellationToken)
        {
            var sport = await _repository.GetByIdAsync(request.Id);

            if (sport == null)
            {
                throw new Exception("Sport doesn't exist!");
            }

            sport.Name = request.UpdateSportDto.Name;
            sport.Description = request.UpdateSportDto.Description;
            sport.Season = request.UpdateSportDto.Season;

            await _repository.UpdateAsync(sport);
            await _repository.SaveChangesAsync();

            return _mapper.Map<SportDto>(sport);
        }
    }
}
