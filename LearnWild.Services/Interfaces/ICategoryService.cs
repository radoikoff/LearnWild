using LearnWild.Web.ViewModels;

namespace LearnWild.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<OptionsViewModel>> AllCategoriesAsync();
    }
}
