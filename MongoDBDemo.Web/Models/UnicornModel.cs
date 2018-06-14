using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBDemo.Web.Models
{
    public class UnicornModel
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string MagicTrick { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
