namespace LearnWild.Common
{
    public static class EntityValidationConstants
    {
        public static class Course
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 300;

            public const int DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 2000;
        }

        public static class CourseType
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
        }

        public static class CourseCategory
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
        }

        public static class Topic
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 300;

            public const int DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 2000;
        }

        public static class Resource
        {
            public const int DisplayNameMinLength = 3;
            public const int DisplayNameMaxLength = 100;

            public const int UrlMinLength = 3;
            public const int UrlMaxLength = 2048;

            public const int FilePathMaxLength = 2048;
        }
    }
}
