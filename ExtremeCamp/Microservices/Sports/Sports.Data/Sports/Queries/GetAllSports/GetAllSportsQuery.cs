using MediatR;
using Sports.Core.Dtos.Sport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Queries.GetAllSports
{
    public class GetAllSportsQuery : IRequest<IEnumerable<SportDto>>
    {
    }
}
