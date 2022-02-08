using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleBookService.Models
{
    [BsonIgnoreExtraElements]
    public class Books
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; } 
        [BsonElement("bookName")]
        public string BookName { get; set; } = String.Empty;
        [BsonElement("authorName")]
        public string AuthorName { get; set; } = String.Empty;
        [BsonElement("timeStamp")]
        public string TimeStamp { get; set; } = String.Empty;
        [BsonElement("category")]
        public String Category { get; set; }
        [BsonElement("description")]
        public string Description { get; set; } = String.Empty;
    }
}
