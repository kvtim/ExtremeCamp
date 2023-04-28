using MediatR;
using Sports.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Commands.DeleteSport
{
    public class DeleteSportCommandHandler : IRequestHandler<DeleteSportCommand, Unit>
    {
        private readonly ISportRepository _repository;

        public DeleteSportCommandHandler(ISportRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSportCommand request, CancellationToken cancellationToken)
        {
            var sport = await _repository.GetByIdAsync(request.Id);

            if (sport == null)
            {
                throw new Exception("Sport doesn't exist!");
            }

            await _repository.RemoveAsync(sport);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
