using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CategoryId { get; set; }
        public string Category { get; set; } = null!;

        public CourseDto(Domain.Entities.Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Description = course.Description;
            Price = course.Price;
            StartDate = course.StartDate;
            EndDate = course.EndDate;
            CategoryId = course.CategoryId;

            Category = course.Category?.Type.ToString() ?? string.Empty;
        }
    }
}
