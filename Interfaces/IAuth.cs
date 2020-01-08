using CruxDotNetReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruxDotNetReact.Interfaces
{
    public interface IAuth
    {
        Task<AppUser> Register(AppUser User, string password);
        Task<AppUser> LoginUser(string User, string password);
    }
}
