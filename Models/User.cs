using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CruxDotNetReact.Models
{
    public class User :IdentityUser<int>
    {
      //  [Key]
      // public int AppUserId { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
