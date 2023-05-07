using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.ErrorHandling;
using Users.Core.Models;

namespace Users.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(T entity);

        Task<Result<T>> GetByIdAsync(int id);
        Task<Result<IEnumerable<T>>> GetAllAsync();
    }
}
