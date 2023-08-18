using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWild.Data.Migrations
{
    public partial class AddQuestionIdColumnInStudentResponses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "StudentResponses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "e2cbc33b-f9d7-4bc2-aabc-0e3b2c69d74a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "bdf50bb0-c496-4db4-9ee3-f27300a67367");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5908dbbd-460c-4418-9fc9-1fe08c903d77", "AQAAAAEAACcQAAAAEDaH4UgqkpiA1AzyExVN3DY8/hGGWvkmvM5xQrYFOvF2Edq7BRc/IkLEYIurlIkSqQ==", "c3109a7d-e7ea-4d89-8175-1bc18bd95187" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad3fb3d0-ab0f-4fc3-91de-d343cb915761", "AQAAAAEAACcQAAAAEDwqDa9rwTwD/2+FDuD28EnThOx05Ky+LtxguXhfCoi6vIZEXDtoiHhpDVAyWGdPCw==", "885bce7b-936f-4eaa-9068-65cea04a9a4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "611e8e2a-13f0-46ea-b6f7-08471cd7a11e", "AQAAAAEAACcQAAAAEG2sy4qXdODZFaehDvyosUTQlBJb9D5wD9snVFw+A+lZpBENaJHHoBlJH8/ngOgKNQ==", "e8337270-e333-4f23-a648-72bbccdaf743" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentResponses_QuestionId",
                table: "StudentResponses",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentResponses_Questions_QuestionId",
                table: "StudentResponses",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentResponses_Questions_QuestionId",
                table: "StudentResponses");

            migrationBuilder.DropIndex(
                name: "IX_StudentResponses_QuestionId",
                table: "StudentResponses");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "StudentResponses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "47774e7e-2b83-45a8-ad37-0f8cbc9b9e57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "365d1969-2c8f-4d69-b94a-14faddf4bd2d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a30da36-d9b5-4fdb-ba1b-1f727968ff5d", "AQAAAAEAACcQAAAAENFOqA8UCgzCYJKzax50Ddhv84TOuJQOCjH5YWTpkbdb5kxTqfIePznbqAJkqFbB+w==", "9f29428b-86b1-4810-a618-61cfac4e8d47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "065b45c8-2898-4ab4-b491-429e15b32ce4", "AQAAAAEAACcQAAAAENjpZytaXEkd6f5bpzMMNYBuUtMlq6323/CyLtB5SwDu541NDGGgTDOUJWqudLy1kQ==", "891330e6-23df-4d1f-a7e2-26f8265cd68e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1838180-4551-48da-acca-03c6e0da4f60", "AQAAAAEAACcQAAAAEGOYSdaHQunPWH9skef5DXagqEpl6DysA8LHmSMAXqVlGoyinLGQ07B5gzbQaMiqHw==", "914713b2-ccf4-4c46-8fe5-43e4f3f4ebc4" });
        }
    }
}
