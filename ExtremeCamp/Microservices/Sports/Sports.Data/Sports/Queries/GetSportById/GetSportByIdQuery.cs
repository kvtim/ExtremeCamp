using MediatR;
using Sports.Core.Dtos.Sport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Sports.Queries.GetSportById
{
    public class GetSportByIdQuery : IRequest<SportDto>
    {
        public int Id { get; set; }
    }
}
