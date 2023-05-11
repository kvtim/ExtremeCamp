using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Models;
using Users.Core.Security;
using Users.Core.Services;
using Users.Core.UnitOfWork;
using Users.Core.Dtos.User;
using Users.Core.ErrorHandling;

namespace Users.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTTokenService _tokenService;
        private readonly IHasher _hasher;

        public AuthenticationService(
            IUnitOfWork unitOfWork,
            IJWTTokenService tokenService,
            IHasher hasher
        )
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _hasher = hasher;
        }

        public async Task<Result<JWTToken>> Authentication(LoginUserDto loginUserDto)
        {
            User user = await _unitOfWork.UserRepository.GetByUserNameAsync(loginUserDto.UserName);

            if (user == null)
            {
                return Result.Failure(ErrorType.BadRequest, "Username is incorrect");
            }

            bool confirmPassword = _hasher.Verify(loginUserDto.Password, user.Password);
            if (!confirmPassword)
            {
                return Result.Failure(ErrorType.BadRequest, "Password is incorrect");
            }

            if (user.Subscription.SubscriptionType != SubscriptionTypes.FREE &&
                user.Subscription.EndDate <= DateTime.Now)
            {
                user.Subscription.SubscriptionType = SubscriptionTypes.FREE;
                user.Subscription.StartDate = DateTime.Now;
                user.Subscription.EndDate = null;

                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.CommitAsync();
            }

            return Result.Ok(await _tokenService.CreateToken(user));
        }
    }
}
