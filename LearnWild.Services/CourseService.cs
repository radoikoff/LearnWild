using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Course;
using LearnWild.Web.ViewModels.Event;
using LearnWild.Web.ViewModels.Registration;
using LearnWild.Web.ViewModels.Topic;
using LearnWild.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
                Start = inputModel.Start ?? DateTime.MinValue,
                End = inputModel.End ?? DateTime.MinValue,
                Active = inputModel.Active,
                MaxCredits = inputModel.Credits,
                Price = inputModel.Price,
                TypeId = inputModel.TypeId,
                CategoryId = inputModel.CategoryId,
                TeacherId = Guid.Parse(inputModel.TeacherId),
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
            course.Start = inputModel.Start ?? DateTime.MinValue;
            course.End = inputModel.End ?? DateTime.MinValue;
            course.Active = inputModel.Active;
            course.MaxCredits = inputModel.Credits;
            course.Price = inputModel.Price;
            course.TypeId = inputModel.TypeId;
            course.CategoryId = inputModel.CategoryId;
            course.TeacherId = Guid.Parse(inputModel.TeacherId);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string id) => await _context.Courses.AnyAsync(c => c.Id == Guid.Parse(id));

        public async Task<IEnumerable<CourseAllViewModel>> GetAllAsync(CourseSearchModel searchModel)
        {
            var coursesQuery = _context.Courses.AsQueryable();

            if (searchModel.SelectedCategories != null)
            {
                coursesQuery = coursesQuery.Where(c => searchModel.SelectedCategories.Contains(c.CategoryId));
            }

            if (searchModel.SelectedTypes != null)
            {
                coursesQuery = coursesQuery.Where(c => searchModel.SelectedTypes.Contains(c.TypeId));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.SearchString))
            {
                string pattern = $"%{searchModel.SearchString.ToLower()}%";

                coursesQuery = coursesQuery.Where(c => EF.Functions.Like(c.Title, pattern) ||
                                                       EF.Functions.Like(c.Description, pattern));
            }

            if (searchModel.Active == true)
            {
                coursesQuery = coursesQuery.Where(c => c.Active == true);
            }

            if (searchModel.MinPrice.HasValue)
            {
                coursesQuery = coursesQuery.Where(c => c.Price >= searchModel.MinPrice);
            }

            if (searchModel.MaxPrice.HasValue)
            {
                coursesQuery = coursesQuery.Where(c => c.Price <= searchModel.MaxPrice);
            }

            var courses = await coursesQuery
                                        .Where(c => c.Deleted == false)
                                        .Select(c => new CourseAllViewModel
                                        {
                                            Id = c.Id.ToString(),
                                            Title = c.Title,
                                            Category = c.Category.Name,
                                            Type = c.Type.Name,
                                            Credits = c.MaxCredits,
                                            Start = c.Start.ToString("dd-MMM-yyyy"),
                                            End = c.End.ToString("dd-MMM-yyyy"),
                                            Active = c.Active,
                                            Price = c.Price,
                                            Teacher = $"{c.Teacher.FirstName} {c.Teacher.LastName}"
                                        })
                                        .ToArrayAsync();
            return courses;
        }

        public async Task<CourseDetailsViewModel?> GetByIdAsync(string id)
        {
            var course = await _context.Courses
                .Where(c => c.Id == Guid.Parse(id))
                .Select(c => new CourseDetailsViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    Category = c.Category.Name,
                    Type = c.Type.Name,
                    Credits = c.MaxCredits,
                    Start = c.Start.ToString("dd-MMM-yyyy HH:mm"),
                    End = c.End.ToString("dd-MMM-yyyy HH:mm"),
                    Active = c.Active,
                    Price = c.Price,
                    TeacherId = c.TeacherId.ToString(),
                    Teacher = $"{c.Teacher.FirstName} {c.Teacher.LastName}",
                    Topics = c.Topics.Select(t => new TopicViewModel
                    {
                        Id = t.Id.ToString(),
                        Title = t.Title,
                        Description = t.Description
                    }).ToArray()
                })
                .FirstOrDefaultAsync();
            return course;
        }

        public async Task<IEnumerable<EventCalendarViewModel>> GetCalendarData()
        {
            return await _context.Courses
                                    .Where(e => e.Active)
                                    .Select(e => new EventCalendarViewModel()
                                    {
                                        Title = e.Title,
                                        Start = e.Start,
                                        End = e.End,
                                        Url = $"/Course/Details/{e.Id}"
                                    })
                                    .ToArrayAsync();
        }

        public async Task<CourseFormModel> GetForEditByIdAsync(string id)
        {
            var courseModel = await _context.Courses
                .Where(c => c.Id == Guid.Parse(id))
                .Select(c => new CourseFormModel
                {
                    Title = c.Title,
                    Description = c.Description,
                    Price = c.Price,
                    Start = c.Start,
                    End = c.End,
                    Active = c.Active,
                    CategoryId = c.CategoryId,
                    TypeId = c.TypeId,
                    Credits = c.MaxCredits,
                    TeacherId = c.TeacherId.ToString(),
                })
                .FirstAsync();

            return courseModel;
        }

        public async Task<CourseScoresViewModel> GetAllStudentsWithScoresAsync(string courseId)
        {
            var model = await _context.Courses.Where(c => c.Id == Guid.Parse(courseId))
                                        .Select(c => new CourseScoresViewModel()
                                        {
                                            CourseId = c.Id.ToString(),
                                            Title = c.Title,
                                            MaxCredits = c.MaxCredits,
                                            Students = c.Registrations.Select(r => new StudentScoreViewModel()
                                            {
                                                Id = r.StudentId.ToString(),
                                                FullName = r.Student.FirstName + " " + r.Student.LastName,
                                                Credits = r.CreditsReceived,
                                                Score = r.Score
                                            })
                                        })
                                        .FirstOrDefaultAsync();

            return model ?? new CourseScoresViewModel();
        }

        public async Task<UserSelectViewModel> GetTeacherAsync(string courseId)
        {
            var teacher = await _context.Courses
                                        .Where(c => c.Id == Guid.Parse(courseId))
                                        .Select(c => new UserSelectViewModel()
                                        {
                                            Id = c.TeacherId.ToString(),
                                            Name = c.Teacher.FirstName + ' ' + c.Teacher.LastName
                                        })
                                        .FirstAsync();
            return teacher;
        }

        public async Task<bool> IsActiveAsync(string courseId)
        {
            return await _context.Courses.AnyAsync(c => c.Id == Guid.Parse(courseId) && c.Active == true);
        }

        public async Task<bool> IsScheduled(DateTime? start, DateTime? end, string teacherId, string? currentCourseId = null)
        {
            var hasOverlap = await _context.Courses.AnyAsync(c => (c.Start < end && c.End > start) &&
                                                                   c.TeacherId.ToString() == teacherId &&
                                                                   c.Id.ToString() != currentCourseId);
            return hasOverlap;
        }

        public async Task<string> GetCourseTitleAsync(string courseId)
        {
            var name = await _context.Courses.Where(c => c.Id == Guid.Parse(courseId))
                                             .Select(c => c.Title)
                                             .FirstOrDefaultAsync();

            return name ?? string.Empty;
        }
    }
}
