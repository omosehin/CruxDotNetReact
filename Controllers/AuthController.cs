using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CruxDotNetReact.Application.Error;
using CruxDotNetReact.Dtos;
using CruxDotNetReact.Interfaces;
using CruxDotNetReact.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CruxDotNetReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IAuth auth, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            //    _auth = auth; 
        }

       [HttpPost("login")]
       public async Task<IActionResult> LoginUser(LoginUserDto users)
        {
            var user = await _userManager.FindByEmailAsync(users.email);

            if (user == null)
                throw new RestException(HttpStatusCode.Unauthorized, new { User = "username is wrong" });

            var result = _signInManager.CheckPasswordSignInAsync(user, users.password, false);

            if (result.IsCompletedSuccessfully)
            {
                return Ok(new {
                    Display_Name= user.DisplayName,
                    User_Name = user.UserName,
                    Phone_Number = user.PhoneNumber,
                    token = _jwtGenerator.CreateToken(user),
                    Image=""
                });
            }

            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}