using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Models.Papras
{
    
    public class Classroom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String IdClassroom { get; set; }

        public String ClassroomName { get; set; }
    }
}
