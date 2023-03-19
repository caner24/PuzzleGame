using PuzzleGame.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Business.Abstract
{
    public interface IGameDetailsService
    {
        Task<List<GameDetail>> GetAllAsync();
        Task<GameDetail> GetByIdAsync(Expression<Func<GameDetail, bool>> filter = null);
        Task<GameDetail> CreateAsync(GameDetail customer);
        Task UpdateAsync(GameDetail entity, Expression<Func<GameDetail, bool>> filter = null);
        Task DeleteAsync(Expression<Func<GameDetail, bool>> filter = null);
    }
}
