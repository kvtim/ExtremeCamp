using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Core.Dtos.Sport
{
    public class CreateSportDto
    {
        public required string? Name { get; set; }
        public required string? Description { get; set; }
        public required string? Season { get; set; }
    }
}
