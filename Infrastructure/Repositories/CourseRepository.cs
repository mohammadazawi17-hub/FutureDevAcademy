using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(FDADbContext context) : base(context) { }

        public async Task<bool> IsStudentEnrolledAsync(int courseId, int studentId)
            => await _context.Enrollments
                .AnyAsync(e => e.CourseId == courseId && e.UserId == studentId);
    }
}
