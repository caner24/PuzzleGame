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
    public class PuzzleService : IPuzzleService
    {
        private IPuzzlesDal _puzzleDal;
        public PuzzleService(IPuzzlesDal puzzleDal)
        {
            _puzzleDal = puzzleDal;
        }
        public Task<Puzzless> CreateAsync(Puzzless customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<Puzzless, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<Puzzless>> GetAllAsync()
        {
            throw new NotImplementedException();
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
