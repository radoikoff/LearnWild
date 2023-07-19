using LearnWild.Web.ViewModels.Course;
using LearnWild.Web.ViewModels.Event;

namespace LearnWild.Services.Interfaces
{
    public interface ICourceService
    {
        Task CreateCourseAsync(CourseFormModel inputModel, string creatorId);
        Task EditCourseAsync(CourseFormModel inputModel, string id);
        Task<bool> ExistsAsync(string id);
        Task<IEnumerable<CourseAllViewModel>> GetAllAsync();
        Task<CourseDetailsViewModel?> GetByIdAsync(string id);
        Task<IEnumerable<EventCalendarViewModel>> GetCalendarData();
        Task<CourseFormModel> GetForEditByIdAsync(string id);
        Task<bool> IsScheduled(DateTime? start, DateTime? end, string teacherId, string? currentCourseId = null);
    }
}
