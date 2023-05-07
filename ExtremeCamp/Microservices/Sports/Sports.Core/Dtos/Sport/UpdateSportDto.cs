using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Core.Dtos.Sport
{
    public class UpdateSportDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Season { get; set; }
    }
}
