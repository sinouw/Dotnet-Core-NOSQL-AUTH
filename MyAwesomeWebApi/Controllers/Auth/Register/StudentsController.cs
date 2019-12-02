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
using MyAwesomeWebApi.Models.Auth.Identity.Roles;
using MyAwesomeWebApi.Models.Identity;
using MyAwesomeWebApi.Models.Requests;
using MyAwesomeWebApi.Models.Responses;

namespace MyAwesomeWebApi.Controllers
{
    [Route("api/students/")]
    public class StudentsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public StudentsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        // POST api/students/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterEntity model)
        {
            if (ModelState.IsValid)
            {

                var user = new Student { Name = model.Name, LastName = model.LastName, City = model.City, UserName = model.Email, Email = model.Email,PhoneNumber=model.PhoneNumber };
                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignInAsync(user, false);
                    var token = AuthenticationHelper.GenerateJwtToken(model.Email, user, _configuration);

                    var rootData = new SignUpResponse(token, user.UserName, user.Email);
                    return Created("api/Students/register", rootData);
                }
                return Ok(string.Join(",", result.Errors?.Select(error => error.Description)));
            }
            string errorMessage = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            return BadRequest(errorMessage ?? "Bad Request");
        }


    }
}
