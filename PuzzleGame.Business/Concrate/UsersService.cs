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
    public class UsersService : IUsersService
    {
        private IUsersDal _userDal;
        public UsersService(IUsersDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<Users> CreateAsync(Users customer)
        {
            return await _userDal.CreateAsync(customer);
        }

        public Task DeleteAsync(Expression<Func<Users, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _userDal.GetAllAsync();
        }

        public Task<Users> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Users entity, Expression<Func<Users, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
