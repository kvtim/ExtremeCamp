using Microsoft.EntityFrameworkCore;
using Sports.Core.Models;
using Sports.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Data.Repositories
{
    public class SportRepository : Repository<Sport>, ISportRepository
    {
        public SportRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Sport> GetSportByNameAsync(string name)
        {
            return await _dbContext.Sports.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
