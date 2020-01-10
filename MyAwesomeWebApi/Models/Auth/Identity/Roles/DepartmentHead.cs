using MongoDB.Bson.Serialization.Attributes;
using MyAwesomeWebApi.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Models.Auth.Identity.Roles
{
    [BsonDiscriminator("DepartmentHead")]
    public class DepartmentHead : ApplicationUser
    {
    }
}
