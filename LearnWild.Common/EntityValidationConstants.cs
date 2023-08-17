namespace LearnWild.Common
{
    public static class EntityValidationConstants
    {
        public static class Course
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 255;

            public const int DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 2000;

            public const string MinDate = "2022/01/01";
            public const string MaxDate = "2050/01/01";

            public const int MinCredit = 0;
            public const int MaxCredit = 100;

            public const string MinPrice = "1";
            public const string MaxPrice = "1000";
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
            public const int TitleMaxLength = 255;

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

            public const int FileNameMaxLength = 2048;

            public const int MimeTypeMaxLength = 255;
        }

        public static class ApplicationUser
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 255;

            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 255;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 64;
        }

        public static class CourseRegistration
        {
            public const decimal MinScore = 2.00m;
            public const decimal MaxScore = 6.00m;
        }

        public static class Quiz
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 255;
        }

        public static class Question
        {
            public const int TextMinLength = 3;
            public const int TextMaxLength = 1024;
        }

        public static class Response
        {
            public const int TextMinLength = 3;
            public const int TextMaxLength = 1024;
        }
    }
}
