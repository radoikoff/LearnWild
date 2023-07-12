using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Services
{
    public class CourseService : ICourceService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCourseAsync(CourseFormModel inputModel, string creatorId)
        {
            var course = new Course
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                Duration = inputModel.Duration,
                MaxCredits = inputModel.Credits,
                Price = inputModel.Price,
                TypeId = inputModel.TypeId,
                CategoryId = inputModel.CategoryId,
                DefaultTeacherId = Guid.Parse(creatorId), //TODO: Add dropdown with all teachers to the view,
                CreatedBy = Guid.Parse(creatorId)
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task EditCourseAsync(CourseFormModel inputModel, string id)
        {
            var course = await _context.Courses.FindAsync(Guid.Parse(id));

            if (course == null)
            {
                throw new InvalidOperationException("Invalid course Id");
            }

            course.Title = inputModel.Title;
            course.Description = inputModel.Description;
            course.Duration = inputModel.Duration;
            course.MaxCredits = inputModel.Credits;
            course.Price = inputModel.Price;
            course.TypeId = inputModel.TypeId;
            course.CategoryId = inputModel.CategoryId;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string id) => await _context.Courses.AnyAsync(c => c.Id == Guid.Parse(id));

        public async Task<IEnumerable<CourseAllViewModel>> GetAllAsync()
        {
            var courses = await _context.Courses
                                        .Select(c => new CourseAllViewModel
                                        {
                                            Id = c.Id.ToString(),
                                            Title = c.Title,
                                            Category = c.Category.Name,
                                            Type = c.Type.Name,
                                            Credits = c.MaxCredits,
                                            Duration = c.Duration,
                                            Price = c.Price
                                        })
                                        .ToArrayAsync();
            return courses;
        }

        public async Task<CourseDetailsViewModel?> GetByIdAsync(string id)
        {
            var course = await _context.Courses
                .Select(c => new CourseDetailsViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    Description = c.Description,
                    Price = c.Price,
                    Category = c.Category.Name,
                    Type = c.Type.Name,
                    Duration = c.Duration,
                    Credits = c.MaxCredits,
                    Topics = c.Topics.Select(t => t.Title).ToArray()
                })
                .FirstOrDefaultAsync(c => c.Id == id);
            return course;
        }

        public async Task<CourseFormModel?> GetForEditByIdAsync(string id)
        {
            var courseModel = await _context.Courses
                .Where(c => c.Id.ToString() == id)
                .Select(c => new CourseFormModel
                {
                    Title = c.Title,
                    Description = c.Description,
                    Price = c.Price,
                    CategoryId = c.CategoryId,
                    TypeId = c.TypeId,
                    Duration = c.Duration,
                    Credits = c.MaxCredits
                })
                .FirstOrDefaultAsync();

            return courseModel;
        }
    }
}
