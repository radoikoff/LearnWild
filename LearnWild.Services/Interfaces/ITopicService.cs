using LearnWild.Web.ViewModels.Topic;

namespace LearnWild.Services.Interfaces
{
    public interface ITopicService
    {
        Task CreateTopicAsync(TopicFormModel model);
        Task EditTopicAsync(TopicFormModel inputModel, string id);
        Task<bool> ExistsAsync(string courseId, string title, string? topicId = null);
        Task<bool> ExistsAsync(string id);
        Task<IEnumerable<AllTopicsViewModel>> GetAllTopicsForCourseAsync(string courseId);
        Task<TopicFormModel?> GetByIdForEditAsync(string id);
    }
}
