using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Spots.Commands.DeleteSpot
{
    public class DeleteSpotCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
