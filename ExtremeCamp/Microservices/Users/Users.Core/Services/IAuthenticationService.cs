using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Dtos.User;
using Users.Core.ErrorHandling;
using Users.Core.Models;

namespace Users.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Result<JWTToken>> Authentication(LoginUserDto loginUserDto);
    }
}
