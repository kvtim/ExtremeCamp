﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Core.Dtos.Spot
{
    public class CreateSpotDto
    {
        public required string? Name { get; set; }
        public required string? Description { get; set; }
        public required string? Location { get; set; }
    }
}
