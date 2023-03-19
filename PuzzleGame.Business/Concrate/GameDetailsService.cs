using PuzzleGame.Business.Abstract;
using PuzzleGame.DataAcess.Abstract;
using PuzzleGame.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Business.Concrate
{
    public class GameDetailsService : IGameDetailsService
    {

        private IGameDetailsDal _gameDetailsService;

        public GameDetailsService(IGameDetailsDal gameDetailsService)
        {
            _gameDetailsService = gameDetailsService;
        }

        public async Task<GameDetail> CreateAsync(GameDetail customer)
        {
          return  await _gameDetailsService.CreateAsync(customer);
        }

        public Task DeleteAsync(Expression<Func<GameDetail, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameDetail>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GameDetail> GetByIdAsync(Expression<Func<GameDetail, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GameDetail entity, Expression<Func<GameDetail, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
