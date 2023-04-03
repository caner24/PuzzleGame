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
            return await _puzzleDal.CreateAsync(customer);
        }

        public async Task DeleteAsync(string id)
        {
            await _puzzleDal.DeleteAsync(id);
        }

        public async Task<List<Puzzless>> GetAllAsync()
        {
            return await _puzzleDal.GetAllAsync();
        }

        public async Task<Puzzless> GetByIdAsync(string id)
        {
            return await _puzzleDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Puzzless entity, string id)
        {
            await _puzzleDal.UpdateAsync(entity, id);
        }
    }
}
