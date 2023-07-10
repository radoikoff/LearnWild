using LearnWild.Data;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LearnWild.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OptionsViewModel>> AllCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new OptionsViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();
        }
    }
}
