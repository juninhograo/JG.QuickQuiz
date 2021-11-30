using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
namespace JG_Domain.Entities
{
    public class Question
    {
        [BsonElement("questionId")]
        public int QuestionId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("answers")]
        public IEnumerable<Answer> Answers { get; set; }
    }
}