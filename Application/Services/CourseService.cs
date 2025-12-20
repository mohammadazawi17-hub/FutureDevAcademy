using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courses;
        private readonly IUnitOfWork _uow;

        public CourseService(ICourseRepository courses, IUnitOfWork uow)
        {
            _courses = courses;
            _uow = uow;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _courses.GetAllAsync();
            return courses.Select(c => new CourseDto(c));
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var course = await _courses.GetByIdAsync(id);
            return course == null ? null : new CourseDto(course);
        }

        public async Task CreateAsync(CreateCourseDto dto)
        {
            var course = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CategoryId = dto.CategoryId
            };

            await _courses.AddAsync(course);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateCourseDto dto)
        {
            var course = await _courses.GetByIdAsync(id)
                ?? throw new Exception("Course not found");

            course.Title = dto.Title;
            course.Description = dto.Description;
            course.Price = dto.Price;
            course.StartDate = dto.StartDate;
            course.EndDate = dto.EndDate;
            course.CategoryId = dto.CategoryId;

            _courses.Update(course);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _courses.GetByIdAsync(id)
                ?? throw new Exception("Course not found");

            _courses.Delete(course);
            await _uow.SaveChangesAsync();
        }
    }
}
