using Microsoft.AspNetCore.Identity;

namespace CruxDotNetReact.Models
{
    public class AppUser :IdentityUser
    {
       public string DisplayName { get; set; }
       
    }
}
