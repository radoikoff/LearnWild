using LearnWild.Web.ViewModels.Course;

namespace LearnWild.Services.Interfaces
{
    public interface ICourceService
    {
        Task CreateCourseAsync(CourseFormModel inputModel, string creatorId);
        Task<bool> ExistsAsync(string id);
        Task<CourseDetailsViewModel?> GetByIdAsync(string id);
    }
}
