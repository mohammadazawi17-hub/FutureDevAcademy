using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task AddAsync(Enrollment enrollment);
        Task<bool> ExistsAsync(int userId, int courseId);

        Task<IEnumerable<int>> GetCourseIdsByStudentAsync(int studentId);
    }
}
