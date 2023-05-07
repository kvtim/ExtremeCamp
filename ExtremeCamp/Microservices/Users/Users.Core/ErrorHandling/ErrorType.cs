﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Core.ErrorHandling
{
    public enum ErrorType
    {
        NotFound = 404,
        BadRequest = 400,
        InternalServerError = 500
    }
}
