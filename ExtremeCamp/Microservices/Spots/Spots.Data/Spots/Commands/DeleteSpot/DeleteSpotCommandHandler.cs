using MediatR;
using Spots.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Commands.DeleteSpot
{
    public class DeleteSpotCommandHandler : IRequestHandler<DeleteSpotCommand, Unit>
    {
        private readonly ISpotRepository _repository;

        public DeleteSpotCommandHandler(ISpotRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSpotCommand request, CancellationToken cancellationToken)
        {
            var spot = await _repository.GetByIdAsync(request.Id);

            if (spot == null)
            {
                throw new Exception("Spot doesn't exist!");
            }

            await _repository.RemoveAsync(spot);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
