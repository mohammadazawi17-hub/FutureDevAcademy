using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class CategorySeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Type = Domain.Enums.CourseCategoryType.IT },
                new Category { Id = 2, Type = Domain.Enums.CourseCategoryType.Sales },
                new Category { Id = 3, Type = Domain.Enums.CourseCategoryType.HR },
                new Category { Id = 4, Type = Domain.Enums.CourseCategoryType.Marketing }
            );
        }
    }
}
