namespace LearnWild.Common
{
    public static class GeneralApplicationConstants
    {
        public static class ApplicationRoles
        {
            public const string TeacherRoleName = "Teacher";
            public const string AdminRoleName = "Admin";
        }

        public static class PolicyNames
        {
            public const string TeacherOrAdmin = "TeacherOrAdmin";
        }

        public static class AppClaimTypes
        {
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
        }
    }
}