using Microsoft.EntityFrameworkCore;
using Spots.Core.Models;
using Spots.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spots.Data.Repositories
{
    public class SpotRepository : Repository<Spot>, ISpotRepository
    {
        public SpotRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Spot> GetSpotByNameAsync(string name)
        {
            return await _dbContext.Spots.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
