using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PuzzleGame.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGame.Entities.Concrate
{
    public class GameDetail:IEntity
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }


        [BsonElement("userid")]
        public string userid { get; set; }

        [BsonElement("puzzleid")]
        public string puzzleid { get; set; }

        [BsonElement("userscore")]
        public int userscore { get; set; }

        [BsonElement("movesmade")]
        public int movesmade { get; set; }
    }
}
