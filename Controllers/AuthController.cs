using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CruxDotNetReact.Application.Error;
using CruxDotNetReact.Dtos;
using CruxDotNetReact.Interfaces;
using CruxDotNetReact.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CruxDotNetReact.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly IAuth _auth;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthController( IAuth auth, IJwtGenerator jwtGenerator)
        {
            _auth = auth;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto users)
        {
            var user =await _auth.RegisterUser(users.Email,users.Password,users.PhoneNumber,users.Username);
            return Ok(new{

                SuccessMessage =String.Format(user.UserName,"{0}created Successfully")
            }) ;
        }

       [HttpPost("login")]
       public async Task<IActionResult> LoginUser(LoginUserDto users)
        {
            var user = await _auth.LoginUser(users.Username, users.Password);

            if (user !=null)
            {
                return Ok(new {
                    Display_Name= user.DisplayName,
                    User_Name = user.UserName,
                    Phone_Number = user.PhoneNumber,
                    token = _jwtGenerator.CreateToken(user).Result,
                    Image=""
                });
            }

            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}