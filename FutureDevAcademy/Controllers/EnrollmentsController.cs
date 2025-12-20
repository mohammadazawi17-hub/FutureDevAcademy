using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutureDevAcademy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Student")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("{courseId}")]
        public async Task<IActionResult> Enroll(int courseId)
        {
            
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "nameid");
            if (userIdClaim == null) return Unauthorized();

            int studentId = int.Parse(userIdClaim.Value);
            await _enrollmentService.EnrollAsync(studentId, courseId);

            return Ok();
        }

        [HttpGet("my-courses")]
        public async Task<IActionResult> GetMyCourses()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "nameid");
            if (userIdClaim == null) return Unauthorized();

            int studentId = int.Parse(userIdClaim.Value);
            var courses = await _enrollmentService.GetStudentCoursesAsync(studentId);

            return Ok(courses);
        }
    }
}
