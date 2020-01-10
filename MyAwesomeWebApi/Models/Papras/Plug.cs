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

        public enum Types { Presence = 0 , Absence = 1, Orientation = 2 }
        public enum States { Waiting = 0, NotApproved = 1, Approved = 2 }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdFile { get; set; }

        public Types Type { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;
        public States State { get; set; } = States.Waiting;

        public string Subject { get; set; }
        public DateTime VerifDate { get; set; }

        public string Description { get; set; }

        public string StudentEmail { get; set; }
        public string TeacherName { get; set; }
    }
}
