using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PuzzleGame.Core.Abstract;
using PuzzleGame.DataAcess.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Core.Concrate
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbConfiguration<TEntity> _dbConfiguration;

        public EfEntityRepositoryBase(DbConfiguration<TEntity> dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
        }

        public async Task<TEntity> CreateAsync(TEntity customer)
        {
            await _dbConfiguration._myCollection.InsertOneAsync(customer).ConfigureAwait(false);
            return customer;
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbConfiguration._myCollection.Find(c => true).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
