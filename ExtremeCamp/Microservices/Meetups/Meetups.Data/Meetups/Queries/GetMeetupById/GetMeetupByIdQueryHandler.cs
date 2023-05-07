using AutoMapper;
using MediatR;
using Meetups.Core.Dtos.Meetup;
using Meetups.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Queries.GetMeetupById
{
    public class GetMeetupByIdQueryHandler : IRequestHandler<GetMeetupByIdQuery, MeetupDto>
    {
        IMeetupRepository _repository;
        IMapper _mapper;

        public GetMeetupByIdQueryHandler(IMeetupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MeetupDto> Handle(GetMeetupByIdQuery request, CancellationToken cancellationToken)
        {
            var meetup = await _repository.GetByIdWithParticipantsAsync(request.Id);

            if (meetup == null)
            {
                throw new KeyNotFoundException("Meetup doesn't exists!");
            }

            return _mapper.Map<MeetupDto>(meetup);
        }
    }
}
