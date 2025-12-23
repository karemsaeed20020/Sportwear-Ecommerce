using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sportwear.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportwear.Infrastructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> _userManager)
        {
            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var defaultuser = new ApplicationUser()
                {
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    BirthDate = new DateTime(1998, 1, 1),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    AccessFailedCount = 0
                };
                await _userManager.CreateAsync(defaultuser, "M123_m");
                await _userManager.AddToRoleAsync(defaultuser, "Admin");
            }
        }
    }
}
