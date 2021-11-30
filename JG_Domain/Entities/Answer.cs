using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JG_Domain.Entities
{
    public class Answer
    {
        [BsonElement("answerId")]
        public int AnswerId { get; set; }

        [BsonElement("order")]
        public string Order { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("image")]
        public string Image { get; set; }

        [BsonElement("right")]
        public bool Right { get; set; }
    }
}