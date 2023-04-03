using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Core.Abstract
{
    public interface IEntityRepositoryBase<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> CreateAsync(T customer);
        Task UpdateAsync(T customer, string id);
        Task DeleteAsync(string id);
    }
}
