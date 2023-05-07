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

namespace Meetups.Data.Meetups.Commands.AddParticipant
{
    public class AddParticipantCommandHandler :
        IRequestHandler<AddParticipantCommand, MeetupDto>
    {
        private readonly IMeetupRepository _repository;
        private readonly IMapper _mapper;

        public AddParticipantCommandHandler(IMeetupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MeetupDto> Handle(AddParticipantCommand request, CancellationToken cancellationToken)
        {
            var meetup = await _repository.GetByIdWithParticipantsAsync(
                request.Participant.MeetupId);

            if (meetup == null)
            {
                throw new KeyNotFoundException("Meetup doesn't exist!");
            }

            if (meetup.Participants.Any(p => p.UserId == request.Participant.UserId))
            {
                throw new ArgumentException("Participant already exists");
            }

            if (request.Role != "Admin" && request.UserId != request.Participant.UserId)
            {
                throw new ArgumentException("You can add to participants only you");
            }

            request.Participant.Meetup = meetup;

            meetup.Participants.Add(request.Participant);

            await _repository.UpdateAsync(meetup);
            await _repository.SaveChangesAsync();

            return _mapper.Map<MeetupDto>(meetup);
        }
    }
}
