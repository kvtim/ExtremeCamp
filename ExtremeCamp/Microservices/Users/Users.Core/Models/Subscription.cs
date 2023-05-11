using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Core.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string SubscriptionType { get; set; } = SubscriptionTypes.FREE;

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
