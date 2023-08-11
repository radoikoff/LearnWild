using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWild.Data.Migrations
{
    public partial class SeedCoursesAndRegistrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "5a05e358-8259-4169-8873-5a955afc5a20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "be2497b3-d4b3-4b8f-a1a1-0f0a2f6a2950");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6370ad30-0997-44e4-b48b-b792f3d917d3", "AQAAAAEAACcQAAAAEK5ZHPjogkybwhU6dpszCitTRHsBOaL4+Zw0FPO8Xovvftc77xqCIPIHHV4gBz/Nng==", "beada985-4172-4178-bec0-6e7134bbc72c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca53d48a-efcc-4e65-bc7f-642d69c420dd", "AQAAAAEAACcQAAAAEIJlAgPdhlYM6x1qIgaGuya4NQHB5zCYMcuyRGigzuudBHTjUKpBjl7MxPBiqhGOcQ==", "f42073ce-542a-4578-a1d3-3e5c9ffe15b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d020dc0f-607b-4e0f-ba4c-6a092658ac9f", "AQAAAAEAACcQAAAAEE0p6/q72Khi+gEfTy+6w6B3RD4ehwXf8AA4xMDmUoeYj3SGllgAatapSaz36wLIeA==", "df3d8025-2a66-4c53-9a30-d928a9cd5f01" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Active", "CategoryId", "CreatedBy", "CreatedOn", "Deleted", "Description", "End", "MaxCredits", "Price", "Start", "TeacherId", "Title", "TypeId" },
                values: new object[,]
                {
                    { new Guid("2cf5e1e6-dc12-428d-950a-c06fc8dbc6c1"), true, 1, new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"), new DateTime(2023, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "An basic course for programming on C# language. Suitable for beginners.", new DateTime(2023, 8, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), 100, null, new DateTime(2023, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"), "Programming Basics with C#", 1 },
                    { new Guid("442d5e89-02d5-4ab3-ae76-07035dffebf1"), true, 4, new Guid("386db847-7c35-4281-a8c6-acd00de18424"), new DateTime(2023, 7, 23, 13, 23, 0, 0, DateTimeKind.Unspecified), false, "An advanced course for project management in software industry", new DateTime(2023, 9, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 0, 300m, new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new Guid("386db847-7c35-4281-a8c6-acd00de18424"), "How to become better manager.", 2 },
                    { new Guid("9d68dc84-acba-4707-8bd9-9504876fe16e"), true, 5, new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"), new DateTime(2023, 7, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "An extensive course about design concepts for wooden houses.", new DateTime(2023, 9, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, 450m, new DateTime(2023, 8, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"), "How to design good looking houses", 1 }
                });

            migrationBuilder.InsertData(
                table: "CourseRegistrations",
                columns: new[] { "CourseId", "StudentId", "AppliedOn", "CompletedOn", "CreditsReceived", "OrderId", "Score", "Status" },
                values: new object[] { new Guid("2cf5e1e6-dc12-428d-950a-c06fc8dbc6c1"), new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"), new DateTime(2023, 8, 5, 18, 32, 10, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 5, 18, 32, 20, 0, DateTimeKind.Unspecified), null, null, null, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseRegistrations",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("2cf5e1e6-dc12-428d-950a-c06fc8dbc6c1"), new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64") });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("442d5e89-02d5-4ab3-ae76-07035dffebf1"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("9d68dc84-acba-4707-8bd9-9504876fe16e"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("2cf5e1e6-dc12-428d-950a-c06fc8dbc6c1"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "b00759e7-e42a-494d-ae7c-ded83f7b4611");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "bbb61b87-a55b-40c5-9bff-1a696a55ea3d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c016e09d-63ee-4bf5-9daa-f0bc2a399be0", "AQAAAAEAACcQAAAAENh3X6A917oXEKYBxSROVugUD7H9j2nGljrlKrhqMZjRYPxVAHWrql6C9O0X3i9vbQ==", "d2728a9f-3441-4c3f-89cc-89822b745506" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a05a1d1-376a-4ea6-b43f-834441c1fc01", "AQAAAAEAACcQAAAAEN9zt5Rg6bo19pRppACatCqliK8W5VXGdEWhIQ8V+mQQNcG0dBdP57sPrYMLMAifBg==", "86347285-0b1f-49f6-a673-ee640b748245" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8432abf6-e3c3-40b6-b6b8-4efd9d9d7b0b", "AQAAAAEAACcQAAAAEMkvrTr0BcJJIEIbm6LZjMof3V+IhcPycz4EEsAG6xjLI1++0FU/XwNQGLRxFayFaA==", "5f3dac21-9fac-408f-b308-f13f4249973c" });
        }
    }
}
