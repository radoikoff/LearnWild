using LearnWild.Web.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserSelectViewModel>> GetTeachersAsync();
		Task<string> GetUserFullNameAsync(string userId);
	}
}
