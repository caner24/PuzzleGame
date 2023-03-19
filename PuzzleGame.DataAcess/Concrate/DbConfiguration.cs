using MongoDB.Driver;
using PuzzleGame.Core.Abstract;
using PuzzleGame.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGame.DataAcess.Concrate
{
    public class DbConfiguration<TEntity>
    {
        public MongoClientSettings _settings { get; set; }
        public MongoClient _client { get; set; }
        public IMongoDatabase _database { get; set; }

        public readonly IMongoCollection<TEntity> _myCollection;
        public DbConfiguration()
        {
            _settings = MongoClientSettings.FromConnectionString("mongodb+srv://caner24:CanerCelep-44@cluster0.x5pu6sm.mongodb.net/?retryWrites=true&w=majority");
            _settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _client = new MongoClient(_settings);
            _database = _client.GetDatabase("PuzzleGame");

            _myCollection = _database.GetCollection<TEntity>(nameof(TEntity));
        }


    }
}
