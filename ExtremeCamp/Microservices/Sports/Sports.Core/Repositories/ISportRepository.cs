using Sports.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Core.Repositories
{
    public interface ISportRepository : IRepository<Sport>
    {
        Task<Sport> GetSportByNameAsync(string name);
    }
}
