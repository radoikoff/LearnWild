using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWild.Data.Migrations
{
    public partial class AddedUserSecurityStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "fabd1ff0-c77a-4ce9-9b6e-0068d1f4746c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "f3d73b4a-c0ee-46f9-91c4-54ee4fa5b1c5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a9259c1-a5f6-41f4-b11f-671b0f2f38e0", "AQAAAAEAACcQAAAAEFlaKQV9yakX+RjMZ2dlWJx+GGNEt5xz3teID13BXHTDZqUqgKcco8lxnsG6NDolEg==", "64f1d8fb-db73-44a4-9967-0d398c13090e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55353e58-2c96-4715-b1ed-ec27bad2d090", "AQAAAAEAACcQAAAAEMz6FHQaRpfgg0bTJwiTc/NKPvI9p8xyxU7Y/+PDC/I7yUKKVZ/AOXJ4GaPn21rkvw==", "dc199bf7-1347-4e47-9639-0bc485a6604b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b5e778c-8d89-4e67-a1bc-3d9b256c0160", "AQAAAAEAACcQAAAAEKj7mAAV2IGFQjSSR1augDBih+dl3uIfTPVZiVizid61h1OolyA3O/z8Fqs+Bfi7tQ==", "2468b318-38e5-4f9a-8c73-5732fa79f569" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "0adc0227-f4f0-4830-8aa4-e11d7c97f82a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "597c85c4-5219-4db8-8d9e-4491f496e37e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ae3a9d9-1634-4dff-9a21-afa56057334b", "AQAAAAEAACcQAAAAEOxmDb0ivmY9KUfH1aeKK5LkwZDQZomBAryfzgsbWrlrS9jBGXHCTF2Kc+uKRGx9VQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3257bd8-d94f-456e-a99b-52233ab8944b", "AQAAAAEAACcQAAAAEKpeov+Eth9A+QJudYm2qs/0YirQQvu7LoDq94QNtVOpSMyMeREPOFBSUBxAbNiyjA==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64d18763-38d7-4bb9-a3cc-ead2a4ad971c", "AQAAAAEAACcQAAAAEAwFvyVsz99J/JuggCcmPacwagZiWXXMKFqloMQ3FXRudfHsWx8rvyAY7r+raZNvuA==", null });
        }
    }
}
