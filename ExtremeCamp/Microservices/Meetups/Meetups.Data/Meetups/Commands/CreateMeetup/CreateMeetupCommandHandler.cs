using AutoMapper;
using MediatR;
using Meetups.Core.Dtos.Meetup;
using Meetups.Core.Models;
using Meetups.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommandHandler :
        IRequestHandler<CreateMeetupCommand, MeetupDto>
    {
        private readonly IMeetupRepository _repository;
        private readonly IMapper _mapper;

        public CreateMeetupCommandHandler(IMeetupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MeetupDto> Handle(CreateMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = await _repository.GetMeetupByOwnerIdAsync(
                request.Meetup.OwnerId);

            if (meetup != null)
            {
                throw new ArgumentException("You already have meetup!");
            }

            request.Meetup.Participants.Add(
                new Participant()
                {
                    MeetupId = request.Meetup.Id,
                    UserId = request.Meetup.OwnerId,
                    Meetup = request.Meetup
                });

            await _repository.AddAsync(request.Meetup);
            await _repository.SaveChangesAsync();

            return _mapper.Map<MeetupDto>(request.Meetup);
        }
    }
}
