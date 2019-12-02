using MyAwesomeWebApi.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Models.Auth.Identity.Roles
{
    public class Student : ApplicationUser
    {


        public string ClassRoomId { get; set; }

        public ICollection<String> Plug { get; set; }


    }
}
