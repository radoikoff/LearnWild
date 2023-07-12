using LearnWild.Web.ViewModels.Course;

namespace LearnWild.Services.Interfaces
{
    public interface ICourceService
    {
        Task CreateCourseAsync(CourseFormModel inputModel, string creatorId);
        Task EditCourseAsync(CourseFormModel inputModel, string id);
        Task<bool> ExistsAsync(string id);
        Task<IEnumerable<CourseAllViewModel>> GetAllAsync();
        Task<CourseDetailsViewModel?> GetByIdAsync(string id);
        Task<CourseFormModel?> GetForEditByIdAsync(string id);
    }
}
