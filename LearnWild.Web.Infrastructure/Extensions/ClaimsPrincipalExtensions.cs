using System.Security.Claims;
using static LearnWild.Common.GeneralApplicationConstants.ApplicationRoles;
using static LearnWild.Common.GeneralApplicationConstants;

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

        public static string GetFirstName(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(AppClaimTypes.FirstName) ?? string.Empty;
        }

        public static string GetLastName(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(AppClaimTypes.LastName) ?? string.Empty;
        }
    }
}
