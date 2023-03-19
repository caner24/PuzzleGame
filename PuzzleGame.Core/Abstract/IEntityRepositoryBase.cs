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
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null);
        Task<T> CreateAsync(T customer);
        Task UpdateAsync(T entity,Expression<Func<T, bool>> filter = null);
        Task DeleteAsync(Expression<Func<T, bool>> filter = null);
    }
}
