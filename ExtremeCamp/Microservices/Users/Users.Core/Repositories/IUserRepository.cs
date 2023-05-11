using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Models;

namespace Users.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdWithSubscriptionAsync(int id);
        Task<IEnumerable<User>> GetAllWithSubscriptionAsync();
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByUserNameAndPasswordAsync(string userName, string password);
    }
}
