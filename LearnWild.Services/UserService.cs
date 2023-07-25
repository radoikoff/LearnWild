using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LearnWild.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserSelectViewModel>> GetTeachersAsync()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");

            return teachers.Select(t => new UserSelectViewModel
            {
                Id = t.Id.ToString(),
                Name = t.UserName,
            });
        }

        public async Task<string> GetUserFullNameAsync(string userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == Guid.Parse(userId));

            if (user == null)
            {
                return string.Empty;
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}
