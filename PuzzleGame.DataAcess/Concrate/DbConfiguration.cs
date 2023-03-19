using MongoDB.Driver;
using PuzzleGame.Core.Abstract;
using PuzzleGame.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGame.DataAcess.Concrate
{
    public static class DbConfiguration
    {
        public static MongoClientSettings _settings { get; set; }
        public static  MongoClient _client { get; set; }
        public static  IMongoDatabase _database { get; set; }



    }
}
