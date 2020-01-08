using CruxDotNetReact.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruxDotNetReact.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id= "a",
                        DisplayName="Yinka",
                        UserName="Ojo",
                        Email="ojo@gmail.com",
                        PhoneNumber ="08142334567"
                    },
                    new AppUser
                    {
                        Id= "a",
                        DisplayName="Abayomi",
                        UserName="Oke",
                        Email="Oke@gmail.com",
                        PhoneNumber ="0831233456"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Lsc1003177@");
                }
            }

            if (!context.Hospitals.Any())
            {
                var hospitals = new List<Hospital>
                {
                   new Hospital
                   {
                       Name = "General Hospital",
                       Location="Gbagada Hospital",
                       DateCreated=DateTime.Now.AddMonths(-24),
                       Email = "GbagadaHospital@gmail.com",
                       State = "Lagos"
                   },
                    new Hospital
                   {
                       Name = "Alausa Hospital",
                       Location="Gbagada Hospital",
                       DateCreated=DateTime.Now.AddMonths(-36),
                       Email = "AlausaHospital@gmail.com",
                       State = "Ilorin"
                   },
                    new Hospital
                   {
                       Name = "Ikeja Hospital",
                       Location="Ikeja Hospital",
                       DateCreated=DateTime.Now.AddMonths(-48),
                       Email = "IkejaHospital@gmail.com",
                       State = "Lagos"
                   }
                };
                context.Hospitals.AddRange(hospitals);
                context.SaveChanges();
            }

        }
    }
}
