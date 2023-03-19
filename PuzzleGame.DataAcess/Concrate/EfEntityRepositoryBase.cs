using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PuzzleGame.Core.Abstract;
using PuzzleGame.DataAcess.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Core.Concrate
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly IMongoCollection<TEntity> _myCollection;

        public EfEntityRepositoryBase()
        {
            DbConfiguration._settings = MongoClientSettings.FromConnectionString("mongodb+srv://caner24:45867-Sas@cluster0.x5pu6sm.mongodb.net/?retryWrites=true&w=majority");
            DbConfiguration._settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            DbConfiguration._client= new MongoClient(DbConfiguration._settings);
            DbConfiguration._database= DbConfiguration._client.GetDatabase("PuzzleGame");
            _myCollection = DbConfiguration._database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<TEntity> CreateAsync(TEntity customer)
        {
            await  _myCollection.InsertOneAsync(customer).ConfigureAwait(false);
            return customer;
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _myCollection.Find(c => true).ToListAsync();
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
