using LearnWild.Web.ViewModels.Topic;

namespace LearnWild.Services.Interfaces
{
    public interface ITopicService
    {
        Task CreateTopicAsync(TopicFormModel model);
        Task<bool> ExistsAsync(string courseId, string title);
        Task<IEnumerable<AllTopicsViewModel>> GetAllTopicsForCourseAsync(string courseId);
    }
}
