using LearnWild.Web.ViewModels.Topic;
using LearnWild.Web.ViewModels.User;

namespace LearnWild.Services.Interfaces
{
    public interface ITopicService
    {
        Task CreateTopicAsync(TopicFormModel model);
        Task DeleteTopicAsync(string topicId);
        Task EditTopicAsync(TopicFormModel inputModel, string id);
        Task<bool> ExistsAsync(string courseId, string title, string? topicId = null);
        Task<bool> ExistsAsync(string id);
        Task<IEnumerable<AllTopicsViewModel>> GetAllTopicsForCourseAsync(string courseId);
        Task<TopicFormModel?> GetByIdForEditAsync(string id);
		Task<UserSelectViewModel> GetTeacherByTopicIdAsync(string topicId);
	}
}
