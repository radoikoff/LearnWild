using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
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

        public async Task<bool> IsUserEnrolled(string studentId, string courseId)
        {
            bool registered = await _dbContext.CourseRegistrations.AnyAsync(r => r.CourseId.ToString() == courseId && 
                                                                                 r.StudentId.ToString() == studentId);
            return registered;
        }

        public async Task Register(string requestorId, string courseId)
        {
            var registration = new CourseRegistration()
            {
                CourseId = Guid.Parse(courseId),
                StudentId = Guid.Parse(requestorId),
                AppliedOn = DateTime.UtcNow,
                Status = Data.Models.Enums.RegisterStatus.Confirmed,
                ConfirmedOn = DateTime.UtcNow
            };

            _dbContext.CourseRegistrations.Add(registration);
            await _dbContext.SaveChangesAsync();
        }
    }
}
