﻿using MediatR;
using Meetups.Core.Dtos.Meetup;
using Meetups.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Commands.DeleteParticipant
{
    public class DeleteParticipantCommandHandler
        : IRequestHandler<DeleteParticipantCommand, Unit>
    {
        private readonly IMeetupRepository _repository;

        public DeleteParticipantCommandHandler(IMeetupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
        {
            var meetup = await _repository.GetByIdWithParticipantsAsync(
                request.MeetupId);

            if (meetup == null)
            {
                throw new KeyNotFoundException("Meetup doesn't exist!");
            }

            if (meetup.OwnerId == request.UserId)
            {
                throw new ArgumentException("Owner can't refuse to his meetup");
            }

            var participant = meetup.Participants
                .FirstOrDefault(p => p.UserId == request.UserId);

            if (participant == null)
            {
                throw new ArgumentException("Participant doesn't exists");
            }

            if (request.Role != "Admin" &&
                meetup.OwnerId != request.CurrentUserId &&
                request.UserId != request.CurrentUserId)
            {
                throw new ArgumentException("You can refuse to participate only you");
            }

            meetup.Participants.Remove(participant);

            await _repository.UpdateAsync(meetup);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
