using LearnWild.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace LearnWild.Data.Seeding
{
    internal static class IdentitySeeder
    {
        internal static IEnumerable<ApplicationUser> GenerateApplicationUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            const string password = "123456";

            var users = new List<ApplicationUser>();

            var teacher = new ApplicationUser()
            {
                Id = Guid.Parse("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                FirstName = "Obi-Wan",
                LastName = "Kenobi",
                UserName = "kenobi@learn.com",
                Email = "kenobi@learn.com",
            };
            users.Add(teacher);

            var secondTeacher = new ApplicationUser()
            {
                Id = Guid.Parse("386db847-7c35-4281-a8c6-acd00de18424"),
                FirstName = "Darth",
                LastName = "Vader",
                UserName = "vader@learn.com",
                Email = "vader@learn.com",
            };
            users.Add(secondTeacher);

            var student = new ApplicationUser()
            {
                Id = Guid.Parse("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                FirstName = "Ivan",
                LastName = "Ivanov",
                UserName = "student@learn.com",
                Email = "student@learn.com",
            };
            users.Add(student);

            foreach (var user in users)
            {
                user.NormalizedEmail = user.Email.ToUpper();
                user.NormalizedUserName = user.UserName.ToUpper();
                user.PasswordHash = hasher.HashPassword(user, password);
                user.SecurityStamp = Guid.NewGuid().ToString();
            }

            return users;
        }

        internal static IEnumerable<IdentityRole<Guid>> GenerateApplicationRoles()
        {
            var roles = new List<IdentityRole<Guid>>();

            var adminRole = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            var teacherRole = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                Name = "Teacher",
                NormalizedName = "TEACHER"
            };

            roles.Add(adminRole);
            roles.Add(teacherRole);

            return roles;
        }

        internal static IEnumerable<IdentityUserRole<Guid>> AssignUsersToRoles()
        {
            var usersRoles = new List<IdentityUserRole<Guid>>()
            {
                new IdentityUserRole<Guid>()
                {
                     RoleId = Guid.Parse("cf31e446-4f8e-4b70-a201-4b73eb510263"), //Teacher Obi-Wan
                     UserId = Guid.Parse("86522b7c-9752-4b0d-a327-59cd8bf8dd62")
                },
                new IdentityUserRole<Guid>()
                {
                     RoleId = Guid.Parse("a806c7be-5b3c-4b69-ae53-8971f082f6ee"), //Admin Obi-Wan
                     UserId = Guid.Parse("86522b7c-9752-4b0d-a327-59cd8bf8dd62")
                },
                new IdentityUserRole<Guid>()
                {
                     RoleId = Guid.Parse("cf31e446-4f8e-4b70-a201-4b73eb510263"), //Teacher Darth
                     UserId = Guid.Parse("386db847-7c35-4281-a8c6-acd00de18424")
                },
            };

            return usersRoles;
        }
    }
}
