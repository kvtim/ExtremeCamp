using AutoMapper;
using MediatR;
using Sports.Core.Dtos.Sport;
using Sports.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Commands.CreateSport
{
    public class CreateSportCommandHandler : IRequestHandler<CreateSportCommand, SportDto>
    {
        private readonly ISportRepository _repository;
        private readonly IMapper _mapper;

        public CreateSportCommandHandler(ISportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SportDto> Handle(CreateSportCommand request, CancellationToken cancellationToken)
        {
            var sport = await _repository.GetSportByNameAsync(request.Sport.Name);

            if (sport != null)
            {
                throw new Exception("Sport already exists!");
            }

            await _repository.AddAsync(request.Sport);
            await _repository.SaveChangesAsync();

            return _mapper.Map<SportDto>(request.Sport);
        }
    }
}
