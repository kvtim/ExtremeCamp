using AutoMapper;
using MediatR;
using Meetups.Core.Dtos.Meetup;
using Meetups.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Queries.GetAllMeetups
{
    public class GetAllMeetupsQueryHandler : IRequestHandler<GetAllMeetupsQuery, IEnumerable<MeetupDto>>
    {
        IMeetupRepository _repository;
        IMapper _mapper;

        public GetAllMeetupsQueryHandler(IMeetupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MeetupDto>> Handle(GetAllMeetupsQuery request, CancellationToken cancellationToken)
        {
            var meetups = await _repository.GetAllWithParticipantsAsync();

            if (!meetups.Any())
            {
                throw new KeyNotFoundException("Meetups don't exist!");
            }

            return _mapper.Map<IEnumerable<MeetupDto>>(meetups);
        }
    }
}
