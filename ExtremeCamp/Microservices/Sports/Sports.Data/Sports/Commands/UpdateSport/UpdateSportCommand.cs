using MediatR;
using Sports.Core.Dtos.Sport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Commands.UpdateSport
{
    public class UpdateSportCommand : IRequest<SportDto>
    {
        public int Id { get; set; }
        public UpdateSportDto UpdateSportDto { get; set; }
    }
}
