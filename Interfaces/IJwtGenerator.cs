using CruxDotNetReact.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruxDotNetReact.Interfaces
{
    public interface IJwtGenerator
    {
         Task<string> CreateToken( User user);
    }
}
