using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Models.Papras
{
    public class Plug
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String IdFile { get; set; }

        public String Type { get; set; }

        public DateTime DateCreation { get; set; }
        public String State { get; set; }

        public String IdStudent { get; set; }
        public String IdTeacher { get; set; }
    }
}
