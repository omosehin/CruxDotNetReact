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
        public static async Task SeedData(DataContext context,
            UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var roles = new List<Role>
                {
                    new Role {Name = "Doctor"},
                    new Role {Name = "Admin"},
                    new Role {Name = "Patient"},
                    new Role {Name = "Visitor"}
                };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }

                var users = new List<User>
                {
                    new User
                    {
                        DisplayName="Yinka",
                        UserName="Ojo",
                        Email="ojo@gmail.com",
                        PhoneNumber ="08142334567"
                    },
                    new User
                    {
                        DisplayName="Abayomi",
                        UserName="Oke",
                        Email="Oke@gmail.com",
                        PhoneNumber ="0831233456"
                    }
                };


                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Lsc1003177");
                    await userManager.AddToRoleAsync(user, "Visitor");

                }

                //create patient user

                var patientUser = new User
                {
                    UserName = "Patient"
                };

                var PResult = userManager.CreateAsync(patientUser, "Lsc1003177@").Result;
                if (PResult.Succeeded)
                {
                    var patient = userManager.FindByNameAsync("Patient").Result;
                    await userManager.AddToRoleAsync(patient, "Patient");
                }

                //create admin user

                var adminUser = new User
                {
                    UserName = "Admin"
                };



                var result = userManager.CreateAsync(adminUser, "Lsc1003177@").Result;
                if (result.Succeeded)
                {
                    var admin = userManager.FindByNameAsync("Admin").Result;
                    await userManager.AddToRoleAsync(admin, "Admin");
                    await userManager.AddToRoleAsync(admin, "Doctor");
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
