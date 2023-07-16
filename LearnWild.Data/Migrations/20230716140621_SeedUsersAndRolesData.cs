using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWild.Data.Migrations
{
    public partial class SeedUsersAndRolesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"), "0adc0227-f4f0-4830-8aa4-e11d7c97f82a", "Admin", "ADMIN" },
                    { new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"), "597c85c4-5219-4db8-8d9e-4491f496e37e", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("386db847-7c35-4281-a8c6-acd00de18424"), 0, "3ae3a9d9-1634-4dff-9a21-afa56057334b", "vader@learn.com", false, "Darth", "Vader", false, null, "VADER@LEARN.COM", "VADER@LEARN.COM", "AQAAAAEAACcQAAAAEOxmDb0ivmY9KUfH1aeKK5LkwZDQZomBAryfzgsbWrlrS9jBGXHCTF2Kc+uKRGx9VQ==", null, false, null, false, "vader@learn.com" },
                    { new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"), 0, "a3257bd8-d94f-456e-a99b-52233ab8944b", "kenobi@learn.com", false, "Obi-Wan", "Kenobi", false, null, "KENOBI@LEARN.COM", "KENOBI@LEARN.COM", "AQAAAAEAACcQAAAAEKpeov+Eth9A+QJudYm2qs/0YirQQvu7LoDq94QNtVOpSMyMeREPOFBSUBxAbNiyjA==", null, false, null, false, "kenobi@learn.com" },
                    { new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"), 0, "64d18763-38d7-4bb9-a3cc-ead2a4ad971c", "student@learn.com", false, "Ivan", "Ivanov", false, null, "STUDENT@LEARN.COM", "STUDENT@LEARN.COM", "AQAAAAEAACcQAAAAEAwFvyVsz99J/JuggCcmPacwagZiWXXMKFqloMQ3FXRudfHsWx8rvyAY7r+raZNvuA==", null, false, null, false, "student@learn.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"), new Guid("386db847-7c35-4281-a8c6-acd00de18424") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"), new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"), new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"), new Guid("386db847-7c35-4281-a8c6-acd00de18424") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"), new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"), new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"));
        }
    }
}
