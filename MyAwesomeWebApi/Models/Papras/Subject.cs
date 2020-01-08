using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Models.Papras
{
    public class Subject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubjId { get; set; }
        public string SubjName { get; set; }

    }
}
