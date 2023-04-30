using AutoMapper;
using MediatR;
using Sports.Core.Dtos.Sport;
using Sports.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Queries.GetAllSports
{
    public class GetAllSportsQueryHandler : IRequestHandler<GetAllSportsQuery, IEnumerable<SportDto>>
    {
        ISportRepository _repository;
        IMapper _mapper;

        public GetAllSportsQueryHandler(ISportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SportDto>> Handle(GetAllSportsQuery request, CancellationToken cancellationToken)
        {
            var sports = await _repository.GetAllAsync();

            if (!sports.Any())
            {
                throw new KeyNotFoundException("Sports don't exist!");
            }

            return _mapper.Map<IEnumerable<SportDto>>(sports);
        }
    }
}
