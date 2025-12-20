using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class AdminSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var admin = new User
            {
                Id = 1,
                FullName = "System Admin",
                Email = "admin@cms.com",
                Role = UserRole.Admin,
                Phone = "0000000000",                       
                DateOfBirth = new DateTime(1990, 1, 1),   
                CreatedAt = new DateTime(2025, 12, 20)    
            };

            var passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123!");

            modelBuilder.Entity<User>().HasData(admin);
        }
    }
}
