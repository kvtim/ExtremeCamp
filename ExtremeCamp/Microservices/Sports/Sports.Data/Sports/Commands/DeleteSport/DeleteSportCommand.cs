using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Commands.DeleteSport
{
    public class DeleteSportCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
