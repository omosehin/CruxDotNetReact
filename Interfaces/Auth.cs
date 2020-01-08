using System;
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
        private readonly DataContext _context;

        public Auth(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
       

        public async Task<AppUser> LoginUser(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
                return null;

            return user;

        }

        public Task<AppUser> Register(AppUser User, string password)
        {
            throw new NotImplementedException();
        }
    }
}
