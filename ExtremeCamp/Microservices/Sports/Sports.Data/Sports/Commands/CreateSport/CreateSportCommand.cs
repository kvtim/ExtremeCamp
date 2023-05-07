using MediatR;
using Sports.Core.Dtos.Sport;
using Sports.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Commands.CreateSport
{
    public class CreateSportCommand : IRequest<SportDto>
    {
        public Sport Sport { get; set; }
    }
}
