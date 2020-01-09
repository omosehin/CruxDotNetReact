using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruxDotNetReact.Models
{
    public class Role :IdentityRole<string>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
