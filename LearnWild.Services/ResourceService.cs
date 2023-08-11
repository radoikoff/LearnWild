using LearnWild.Data;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Resource;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Services
{
    public class ResourceService : IResourceService
    {
        private readonly ApplicationDbContext _dbContext;

        public ResourceService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> CreateResourseAsync(ResourceFormModel model)
        {
            throw new NotImplementedException();
        }
    }
}
