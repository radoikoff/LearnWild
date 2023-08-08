using LearnWild.Web.ViewModels.Topic;

namespace LearnWild.Services.Interfaces
{
    public interface ITopicService
    {
        Task<IEnumerable<AllTopicsViewModel>> GetAllTopicsForCourseAsync(string courseId);
    }
}
