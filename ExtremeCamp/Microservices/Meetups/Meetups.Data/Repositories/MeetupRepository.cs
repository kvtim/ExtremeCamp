using Microsoft.EntityFrameworkCore;
using Meetups.Core.Models;
using Meetups.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Data.Repositories
{
    public class MeetupRepository : Repository<Meetup>, IMeetupRepository
    {
        public MeetupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Meetup> GetByIdWithParticipantsAsync(int id)
        {
            return await _dbSet.Include(c => c.Participants)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Meetup>> GetAllWithParticipantsAsync()
        {
            return await _dbSet.Include(c => c.Participants).ToListAsync();
        }

        public async Task<Meetup> GetMeetupByOwnerIdAsync(int ownerId)
        {
            return await _dbContext.Meetups.FirstOrDefaultAsync(
                s => s.OwnerId == ownerId);
        }
    }
}
