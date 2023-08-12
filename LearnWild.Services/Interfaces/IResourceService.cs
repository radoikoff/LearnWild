using LearnWild.Web.ViewModels.Resource;
namespace LearnWild.Services.Interfaces
{
    public interface IResourceService
    {
        Task<bool> CreateResourseAsync(ResourceFormModel model);
        Task<bool> ExistsAsync(string topicId, string displayName);
        Task<bool> ExistsAsync(string id);
        Task<ResourceFileInfoModel?> GetResourseFileInfo(string id);
    }
}
