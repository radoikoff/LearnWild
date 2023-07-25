using LearnWild.Web.ViewModels.Registration;

namespace LearnWild.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task EditStudentScoreAsync(string studentId, string courseId, decimal? score, int? credits);
        Task<IEnumerable<RegistrationsViewModel>> GetRegistrationsByStudentIdAsync(string studentId);
		Task<StudentScoreFormModel> GetStudentScoresAsync(string studentId, string courseId);
		Task<bool> IsUserEnrolledAsync(string studentId, string courseId);
        Task RegisterAsync(string requestorId, string courseId);
    }
}
