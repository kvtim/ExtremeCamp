using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Requests
{
    public class GetUserByUsername
    {
        public required string Username { get; set; }
    }
}
