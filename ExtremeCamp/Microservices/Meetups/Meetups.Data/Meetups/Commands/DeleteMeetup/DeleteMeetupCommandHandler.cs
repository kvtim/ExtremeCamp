using MediatR;
using Meetups.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Meetups.Commands.DeleteMeetup
{
    public class DeleteMeetupCommandHandler : IRequestHandler<DeleteMeetupCommand, Unit>
    {
        private readonly IMeetupRepository _repository;

        public DeleteMeetupCommandHandler(IMeetupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = await _repository.GetByIdAsync(request.Id);

            if (meetup == null)
            {
                throw new KeyNotFoundException("Meetup doesn't exist!");
            }

            await _repository.RemoveAsync(meetup);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
