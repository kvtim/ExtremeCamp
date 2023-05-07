using Meetups.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Core.Repositories
{
    public interface IMeetupRepository : IRepository<Meetup>
    {
        Task<Meetup> GetByIdWithParticipantsAsync(int id);
        Task<IEnumerable<Meetup>> GetAllWithParticipantsAsync();
        Task<Meetup> GetMeetupByOwnerIdAsync(int ownerId);
    }
}
