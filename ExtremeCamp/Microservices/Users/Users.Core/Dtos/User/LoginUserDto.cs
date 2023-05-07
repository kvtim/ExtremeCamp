﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Validation;

namespace Users.Core.Dtos.User
{
    public class LoginUserDto
    {
        [UsernameValidation]
        public required string? UserName { get; set; }

        [PasswordValidation]
        public required string? Password { get; set; }
    }
}
