using AutoMapper;
using MediatR;
using Sports.Core.Dtos.Sport;
using Sports.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Queries.GetSportById
{
    public class GetSportByIdQueryHandler : IRequestHandler<GetSportByIdQuery, SportDto>
    {
        ISportRepository _repository;
        IMapper _mapper;

        public GetSportByIdQueryHandler(ISportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SportDto> Handle(GetSportByIdQuery request, CancellationToken cancellationToken)
        {
            var sport = await _repository.GetByIdAsync(request.Id);

            if (sport == null)
            {
                throw new Exception("Sport doesn't exists!");
            }

            return _mapper.Map<SportDto>(sport);
        }
    }
}
