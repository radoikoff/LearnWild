using LearnWild.Data;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LearnWild.Services
{
    public class TypeService : ITypeService
    {
        private readonly ApplicationDbContext _context;

        public TypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OptionsViewModel>> AllTypesAsync()
        {
            return await _context.CourseTypes
                .Select(c => new OptionsViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();
        }
    }
}
