using PuzzleGame.Business.Abstract;
using PuzzleGame.DataAcess.Abstract;
using PuzzleGame.DataAcess.Concrate;
using PuzzleGame.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Business.Concrate
{
    public class PuzzleService : IPuzzleService
    {
        private IPuzzlesDal _puzzleDal;
        public PuzzleService(IPuzzlesDal puzzleDal)
        {
            _puzzleDal = puzzleDal;
        }
        public async Task<Puzzless> CreateAsync(Puzzless customer)
        {
         return   await _puzzleDal.CreateAsync(customer);
        }

        public Task DeleteAsync(Expression<Func<Puzzless, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Puzzless>> GetAllAsync()
        {
			return await _puzzleDal.GetAllAsync();
		}

        public Task<Puzzless> GetByIdAsync(Expression<Func<Puzzless, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Puzzless entity, Expression<Func<Puzzless, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
