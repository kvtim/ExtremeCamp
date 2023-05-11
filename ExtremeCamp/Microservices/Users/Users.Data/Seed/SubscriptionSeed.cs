using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Models;

namespace Users.Data.Seed
{
    public class SubscriptionSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new Subscription()
                {
                    Id = 1,
                    SubscriptionType = SubscriptionTypes.FREE,
                    UserId = 1
                });

            builder.HasData(
                new Subscription()
                {
                    Id = 2,
                    SubscriptionType = SubscriptionTypes.FREE,
                    UserId = 2
                });
        }
    }
}
