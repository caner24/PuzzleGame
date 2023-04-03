using PuzzleGame.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Business.Abstract
{
    public interface IPuzzleService
    {
        Task<List<Puzzless>> GetAllAsync();
        Task<Puzzless> GetByIdAsync(string id);
        Task<Puzzless> CreateAsync(Puzzless customer);
        Task UpdateAsync(Puzzless customer,string id);
        Task DeleteAsync(string id);
    }
}
