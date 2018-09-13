﻿using LambdaForums.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaForums.Data
{
    public class DataSeeder
    {
        private ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedSupportUser()
        {
            var user = new ApplicationUser
            {
                UserName = "ForumAdmin",
                NormalizedUserName = "forumadmin",
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            //Define  user.PasswordHash down here so that we have the user defined
            var hasher = new PasswordHasher<ApplicationUser>();
            var hashedPassword = hasher.HashPassword(user, "admin");

            user.PasswordHash = hashedPassword;

            var roleStore = new RoleStore<IdentityRole>(_context);
            var userStore = new UserStore<ApplicationUser>(_context);

            var isAdminRole = _context.Roles.Any(roles => roles.Name == "Admin");
            if (!isAdminRole)
            {
                 roleStore.CreateAsync(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "admin"
                });
            }

            var hasSuperUser = 
                _context.Users.Any(u => u.NormalizedUserName == user.UserName);  // chck to say if the database has a superser
            if(!hasSuperUser)
            {
                 userStore.CreateAsync(user);
                 userStore.AddToRoleAsync(user, "Admin");

            }

             _context.SaveChanges();

           // return Task.CompletedTask;
        }
    }
}
