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
    }
}
