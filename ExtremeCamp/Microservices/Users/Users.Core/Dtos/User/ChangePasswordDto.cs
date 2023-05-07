using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Validation;

namespace Users.Core.Dtos.User
{
    public class ChangePasswordDto
    {
        [PasswordValidation]
        public required string? OldPassword { get; set; }

        [PasswordValidation]
        public required string NewPassword { get; set; }
    }
}
