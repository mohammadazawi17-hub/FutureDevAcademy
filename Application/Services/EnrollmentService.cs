using Application.Common;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollments;
        private readonly IUnitOfWork _uow;

        public EnrollmentService(
            IEnrollmentRepository enrollments,
            IUnitOfWork uow)
        {
            _enrollments = enrollments;
            _uow = uow;
        }

        public async Task<Result> EnrollAsync(int studentId, int courseId)
        {
            if (await _enrollments.ExistsAsync(studentId, courseId))
                return Result.Fail("Student already enrolled"); // use Result pattern instead of throwing

            var enrollment = new Enrollment
            {
                UserId = studentId,
                CourseId = courseId
            };

            await _enrollments.AddAsync(enrollment);
            await _uow.SaveChangesAsync();

            return Result.Ok(); // indicate enrollment succeeded
        }

        public async Task<IEnumerable<int>> GetStudentCoursesAsync(int studentId)
        {
            return await _enrollments.GetCourseIdsByStudentAsync(studentId);
        }
    }
}
