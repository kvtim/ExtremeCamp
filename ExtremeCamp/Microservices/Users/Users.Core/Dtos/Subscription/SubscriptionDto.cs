using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Core.Dtos.Subscription
{
    public class SubscriptionDto
    {
        public string SubscriptionType { get; set; }

        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
    }
}
