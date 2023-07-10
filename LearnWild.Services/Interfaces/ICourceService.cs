using LearnWild.Web.ViewModels.Course;

namespace LearnWild.Services.Interfaces
{
    public interface ICourceService
    {
        Task CreateCourseAsync(CourseFormModel inputModel, string creatorId);
    }
}
