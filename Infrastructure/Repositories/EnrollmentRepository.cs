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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly FDADbContext _context;

        public EnrollmentRepository(FDADbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Enrollment enrollment)
            => await _context.Enrollments.AddAsync(enrollment);

        public async Task<bool> ExistsAsync(int userId, int courseId)
            => await _context.Enrollments
                .AnyAsync(e => e.UserId == userId && e.CourseId == courseId);

        public async Task<IEnumerable<int>> GetCourseIdsByStudentAsync(int studentId)
        {
            return await _context.Enrollments
                .Where(e => e.UserId == studentId)
                .Select(e => e.CourseId)
                .ToListAsync();
        }
    }
}
