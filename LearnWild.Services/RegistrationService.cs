using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Data.Models.Enums;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Registration;
using Microsoft.EntityFrameworkCore;

namespace LearnWild.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext _dbContext;

        public RegistrationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task EditStudentScoreAsync(string studentId, string courseId, decimal? score, int? credits)
        {
            var registration = await _dbContext.CourseRegistrations
                .FirstOrDefaultAsync(r => r.StudentId == Guid.Parse(studentId) && r.CourseId == Guid.Parse(courseId));

            if (registration == null)
            {
                throw new InvalidOperationException("Such registration does not exists!");
            }

            registration.Score = score;
            registration.CreditsReceived = credits;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RegistrationsViewModel>> GetRegistrationsByStudentIdAsync(string studentId)
        {
            var registrations = await _dbContext.CourseRegistrations
                                                .Where(r => r.StudentId.ToString() == studentId &&
                                                            r.Status == RegisterStatus.Completed)
                                                .Select(r => new RegistrationsViewModel()
                                                {
                                                    CourseId = r.CourseId.ToString(),
                                                    Title = r.Course.Title,
                                                    Category = r.Course.Category.Name,
                                                    Type = r.Course.Type.Name,
                                                    Start = r.Course.Start.ToString("dd-MMM-yyyy"),
                                                    End = r.Course.End.ToString("dd-MMM-yyyy"),
                                                    CreditsReceived = r.CreditsReceived,
                                                    Score = r.Score,
                                                    HasStarted = r.Course.Active &&
                                                                r.Course.Start <= DateTime.UtcNow &&
                                                                r.Course.End >= DateTime.UtcNow,
                                                    InFuture = r.Course.Active && r.Course.Start > DateTime.UtcNow,
                                                    Teacher = r.Course.Teacher.FirstName + ' ' + r.Course.Teacher.LastName,
                                                    IsPaid = r.OrderId.HasValue
                                                })
                                                .ToArrayAsync();
            return registrations;
        }

        public async Task<StudentScoreFormModel> GetStudentScoresAsync(string studentId, string courseId)
        {
            var model = await _dbContext.CourseRegistrations
                .Where(cr => cr.StudentId == Guid.Parse(studentId) && cr.CourseId == Guid.Parse(courseId))
                .Select(r => new StudentScoreFormModel()
                {
                    CourseId = r.CourseId.ToString(),
                    StudentId = r.StudentId.ToString(),
                    Credits = r.CreditsReceived,
                    CourseMaxCredits = r.Course.MaxCredits,
                    Score = r.Score,
                    StudentFullName = r.Student.FirstName + " " + r.Student.LastName,
                    CourseTitle = r.Course.Title,
                })
                .FirstOrDefaultAsync();
            return model ?? new StudentScoreFormModel();
        }

        public async Task<bool> IsUserEnrolledAsync(string studentId, string courseId)
        {
            bool registered = await _dbContext.CourseRegistrations.AnyAsync(r => r.CourseId.ToString() == courseId &&
                                                                                 r.StudentId.ToString() == studentId);
            return registered;
        }

        public async Task RegisterAsync(string requestorId, string courseId)
        {
            var registration = new CourseRegistration()
            {
                CourseId = Guid.Parse(courseId),
                StudentId = Guid.Parse(requestorId),
                AppliedOn = DateTime.UtcNow,
                Status = RegisterStatus.Completed,
                CompletedOn = DateTime.UtcNow
            };

            _dbContext.CourseRegistrations.Add(registration);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveStudentFromCourseAsync(string studentId, string courseId)
        {
            var registration = await _dbContext.CourseRegistrations
                .FirstOrDefaultAsync(r => r.CourseId == Guid.Parse(courseId) && r.StudentId == Guid.Parse(studentId));

            if (registration == null)
            {
                throw new InvalidOperationException("Registration not found!");
            }

            _dbContext.CourseRegistrations.Remove(registration);
            await _dbContext.SaveChangesAsync();
        }
    }
}
