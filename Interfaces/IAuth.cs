using CruxDotNetReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruxDotNetReact.Interfaces
{
    public interface IAuth
    {
        Task<User> RegisterUser(string Email, string Password,string PhoneNumber, string Username);
        Task<User> LoginUser(string Email, string password);
    }
}
