using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Course;
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
    }
}
