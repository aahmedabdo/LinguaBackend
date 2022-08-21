using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ligunaApplication.Models
{
    public class RateEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; } = String.Empty;
        [BsonElement("RateCount")]
        public int RateCount { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("Notes")]
        public string Notes { get; set; } = String.Empty;
        [BsonElement("CreationDate")]
        public DateTime CreationDate { get; set; }
    }
}
