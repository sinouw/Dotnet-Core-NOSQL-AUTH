using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyAwesomeWebApi.Helpers;
using MyAwesomeWebApi.Models;
using MyAwesomeWebApi.Models.Identity;
using MyAwesomeWebApi.Models.Requests;
using MyAwesomeWebApi.Models.Responses;

namespace MyAwesomeWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        private readonly UserService userService;
        
        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            userService = new UserService("awesomedatabase", "users", "mongodb://localhost:27017");

        }

        // GET api/user/getallusers
        [HttpGet]
        public async Task<ActionResult> getAllUsers()
        {
            var allusers = await userService.GetAllUsers();
            return Ok(allusers);
        }

        // GET api/user/userdata
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult> UserData()
        {
            var user = await _userManager.GetUserAsync(User);
            //var role = _userManager.GetRolesAsync(user);
            var userData = new UserDataResponse
            {
                Name = user.UserName,
                LastName = user.LastName,
                City = user.City,
                Email = user.Email,
                Role = user.Roles[0]
            };
            return Ok(userData);
        }

        // PUT api/user/UpdateUserById/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserById(string id, [FromBody]ApplicationUser appuser)
        {
             await userService.UpdateUserbyId(id,appuser);

            return NoContent();
        }

        // Delete api/user/delete/5
        [HttpDelete("delete/{id:length(24)}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            await userService.DeleteUser(id);
            return NoContent();

        }
    }
}
