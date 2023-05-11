using EventBus.Messages.Requests;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Models;
using Users.Core.Services;

namespace Users.Api.EventBusConsumer
{
    public class GetUserByUserNameConsumer : IConsumer<GetUserByUsername>
    {
        private readonly IUserService _userService;

        public GetUserByUserNameConsumer(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Consume(ConsumeContext<GetUserByUsername> context)
        {
            var userResult = await _userService.GetByUserNameAsync(context.Message.Username);

            if (!userResult.Succeeded)
            {
                throw new ArgumentException("User not found");
            }

            var user = userResult.ValueOrDefault;

            await context.RespondAsync(new GetUserByUserNameResult()
            {
                UserId = user.Id,
                Email= user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Role = user.Role.ToString(),
                isPremium = user.Subscription.SubscriptionType != SubscriptionTypes.FREE
            });
        }
    }
}
