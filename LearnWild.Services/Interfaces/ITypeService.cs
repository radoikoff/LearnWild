using LearnWild.Web.ViewModels;

namespace LearnWild.Services.Interfaces
{
    public interface ITypeService
    {
        Task<IEnumerable<OptionsViewModel>> AllTypesAsync();
    }
}
