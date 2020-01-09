﻿using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace CruxDotNetReact.Models
{
    public class AppUser :IdentityUser
    {
       public string DisplayName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
