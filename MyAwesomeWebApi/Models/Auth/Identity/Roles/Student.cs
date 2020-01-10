using MongoDB.Bson.Serialization.Attributes;
using MyAwesomeWebApi.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Models.Auth.Identity.Roles
{
    [BsonDiscriminator("Student")]
    public class Student : ApplicationUser
    {
        //public String ClassroomId { get; set; }
        //public ICollection<String> Plugs { get; set; }


    }
}
