using LearnWild.Web.ViewModels.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Services.Interfaces
{
    public interface IResourceService
    {
        Task<bool> CreateResourseAsync(ResourceFormModel model);
    }
}
