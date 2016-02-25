
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace WebApiExample.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Mode { get; set; }

        public static void RegisterClassMap()
        {
            BsonClassMap.RegisterClassMap<Book>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.CompletionDate).SetElementName("completionDate");
                cm.MapMember(c => c.Mode).SetElementName("mode");
                cm.MapMember(c => c.Title).SetElementName("title");
                cm.MapMember(c => c.Author).SetElementName("author");
            });
        }
    }
}
