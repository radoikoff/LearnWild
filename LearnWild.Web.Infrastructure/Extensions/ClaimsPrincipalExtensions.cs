using System.Security.Claims;
using static LearnWild.Common.GeneralApplicationConstants.ApplicationRoles;

namespace LearnWild.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier)?.ToUpperInvariant() ?? string.Empty;
        }

        public static bool IsTeacher(this ClaimsPrincipal user)
        {
            return user.IsInRole(TeacherRoleName);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }
    }
}
