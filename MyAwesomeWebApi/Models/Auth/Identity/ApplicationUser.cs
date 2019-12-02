using System;
using AspNetCore.Identity.Mongo;
using MongoDB.Bson.Serialization.Attributes;

namespace MyAwesomeWebApi.Models.Identity
{
    //Add any custom field for a user
    public class ApplicationUser : MongoIdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        [BsonDateTimeOptions]
        // attribute to gain control on datetime serialization
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public Boolean Enabled { get; set; } = true;
    }
}
