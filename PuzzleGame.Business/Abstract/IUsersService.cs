using PuzzleGame.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Business.Abstract
{
    public interface IUsersService
    {
        Task<List<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(string id);
        Task<Users> CreateAsync(Users customer);
        Task UpdateAsync(Users entity, Expression<Func<Users, bool>> filter = null);
        Task DeleteAsync(Expression<Func<Users, bool>> filter = null);
    }
}
