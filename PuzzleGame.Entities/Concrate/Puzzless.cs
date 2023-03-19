using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleGame.Entities.Concrate
{
    public class Puzzless
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("puzzlename")]
        public string puzzlename { get; set; }

        [BsonElement("puzzlepicture")]
        public byte [] puzzlepicture { get; set; }
    }
}
