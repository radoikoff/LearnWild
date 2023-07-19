namespace LearnWild.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<bool> IsUserEnrolled(string studentId, string courseId);
        Task Register(string requestorId, string courseId);
    }
}
