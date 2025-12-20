using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Result> EnrollAsync(int studentId, int courseId);
        Task<IEnumerable<int>> GetStudentCoursesAsync(int studentId);
    }
}
