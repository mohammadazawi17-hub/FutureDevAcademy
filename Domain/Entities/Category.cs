using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public CourseCategoryType Type { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
