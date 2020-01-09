﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CruxDotNetReact.Application.Error;
using CruxDotNetReact.Data;
using CruxDotNetReact.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CruxDotNetReact.Interfaces
{
    public class Auth : IAuth
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly DataContext _context;

        public Auth(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            _context = context;
        }
       

        public async Task<AppUser> LoginUser(string Email, string password)
        {

            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
                throw new RestException(HttpStatusCode.Unauthorized, new { User = "username is wrong" });

            var result = _signInManager.CheckPasswordSignInAsync(user, password, false);


            if (result.IsCompletedSuccessfully)
            {
                return (user);
            }

            throw new RestException(HttpStatusCode.Unauthorized);

        }


 
        public async Task<AppUser> RegisterUser(string Email, string Password,string PhoneNumber ,string Username)
        {
            var userToCreate = new AppUser
            {
                Email = Email,
                UserName = Username,
                PhoneNumber =PhoneNumber,
            };
            var userFromDb = await _userManager.FindByEmailAsync(userToCreate.Email);
           
            if(userFromDb != null)
            {
                throw new RestException(HttpStatusCode.BadRequest, new { User = "User already exist" });
            }
            var user = await _userManager.CreateAsync(userToCreate,Password);
            
            if (user.Succeeded)
            {
                return new AppUser { 
                      DisplayName = String.Format(userToCreate.UserName, "{0} is successfully created")
                };
            }

            throw new Exception("User not created");
                
               

        }
    }
}
