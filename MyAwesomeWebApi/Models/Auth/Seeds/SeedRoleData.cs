using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAwesomeWebApi.Models.Auth.Settings;
using MyAwesomeWebApi.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace MyAwesomeWebApi.Models.Auth.Seeds
{
    public class SeedRoleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
        }
    }
}
