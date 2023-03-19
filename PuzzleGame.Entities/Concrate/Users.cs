using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PuzzleGame.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PuzzleGame.Entities.Concrate
{
    public class Users : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("username")]
        public string username { get; set; }
    }
}
