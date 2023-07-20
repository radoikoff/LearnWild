using LearnWild.Web.ViewModels.Registration;

namespace LearnWild.Services.Interfaces
{
    public interface IRegistrationService
    {
		Task<IEnumerable<RegistrationsViewModel>> GetRegistrationsByStudentIdAsync(string studentId);
		Task<bool> IsUserEnrolledAsync(string studentId, string courseId);
        Task RegisterAsync(string requestorId, string courseId);
    }
}
