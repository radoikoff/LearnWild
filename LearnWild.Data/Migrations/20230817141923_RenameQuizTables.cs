using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWild.Data.Migrations
{
    public partial class RenameQuizTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Courses_CourseId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempt_AspNetUsers_StudentId",
                table: "QuizAttempt");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempt_Quiz_QuizId",
                table: "QuizAttempt");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Question_QuestionId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentResponse_QuizAttempt_QuizAttemptId",
                table: "StudentResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentResponse_Response_ResponseId",
                table: "StudentResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentResponse",
                table: "StudentResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Response",
                table: "Response");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAttempt",
                table: "QuizAttempt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "StudentResponse",
                newName: "StudentResponses");

            migrationBuilder.RenameTable(
                name: "Response",
                newName: "Responses");

            migrationBuilder.RenameTable(
                name: "QuizAttempt",
                newName: "QuizAttempts");

            migrationBuilder.RenameTable(
                name: "Quiz",
                newName: "Quizzes");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_StudentResponse_ResponseId",
                table: "StudentResponses",
                newName: "IX_StudentResponses_ResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentResponse_QuizAttemptId",
                table: "StudentResponses",
                newName: "IX_StudentResponses_QuizAttemptId");

            migrationBuilder.RenameIndex(
                name: "IX_Response_QuestionId",
                table: "Responses",
                newName: "IX_Responses_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAttempt_StudentId",
                table: "QuizAttempts",
                newName: "IX_QuizAttempts_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAttempt_QuizId",
                table: "QuizAttempts",
                newName: "IX_QuizAttempts_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_CourseId",
                table: "Quizzes",
                newName: "IX_Quizzes_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_QuizId",
                table: "Questions",
                newName: "IX_Questions_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentResponses",
                table: "StudentResponses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAttempts",
                table: "QuizAttempts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempts_AspNetUsers_StudentId",
                table: "QuizAttempts",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempts_Quizzes_QuizId",
                table: "QuizAttempts",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Courses_CourseId",
                table: "Quizzes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentResponses_QuizAttempts_QuizAttemptId",
                table: "StudentResponses",
                column: "QuizAttemptId",
                principalTable: "QuizAttempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentResponses_Responses_ResponseId",
                table: "StudentResponses",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempts_AspNetUsers_StudentId",
                table: "QuizAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempts_Quizzes_QuizId",
                table: "QuizAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Courses_CourseId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentResponses_QuizAttempts_QuizAttemptId",
                table: "StudentResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentResponses_Responses_ResponseId",
                table: "StudentResponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentResponses",
                table: "StudentResponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAttempts",
                table: "QuizAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "StudentResponses",
                newName: "StudentResponse");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "Response");

            migrationBuilder.RenameTable(
                name: "Quizzes",
                newName: "Quiz");

            migrationBuilder.RenameTable(
                name: "QuizAttempts",
                newName: "QuizAttempt");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameIndex(
                name: "IX_StudentResponses_ResponseId",
                table: "StudentResponse",
                newName: "IX_StudentResponse_ResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentResponses_QuizAttemptId",
                table: "StudentResponse",
                newName: "IX_StudentResponse_QuizAttemptId");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_QuestionId",
                table: "Response",
                newName: "IX_Response_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_CourseId",
                table: "Quiz",
                newName: "IX_Quiz_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAttempts_StudentId",
                table: "QuizAttempt",
                newName: "IX_QuizAttempt_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAttempts_QuizId",
                table: "QuizAttempt",
                newName: "IX_QuizAttempt_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuizId",
                table: "Question",
                newName: "IX_Question_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentResponse",
                table: "StudentResponse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Response",
                table: "Response",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAttempt",
                table: "QuizAttempt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "e14bc835-bfa9-4d49-a795-ad8337953016");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "6daf183f-6c73-4a80-b282-f266a399deef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf9b378f-c806-4a48-a445-8581e51dd01b", "AQAAAAEAACcQAAAAECAP+kUmCNmhYvdd6ShLMwF+wtN9hfInxTtdE6sXZBSqQn4HFM8svdvS+gak4ACcRg==", "2ecde34e-8e2c-446b-be6f-24d189496c70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d539e4f8-e2c9-432b-bfbd-4b3c66804538", "AQAAAAEAACcQAAAAEIUKVxmyT9KZ0YZFTrL8dpdp6qmnnKIqZjNCyzCXzm0SkhLaxC22ktZRtnHVnvmEKA==", "13d08079-8a7d-4d6e-9bd4-c46ab4f0a3db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc3b2d04-e824-4202-807c-5ba72363947d", "AQAAAAEAACcQAAAAEKClzwWn6Pb6zbUt/dtPipq9Qz86ITFKSHd+1FLoDguS1LfJmZiR9OpXY09W1ghHUQ==", "c8baea2c-3704-4022-b165-029fac3e702b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Courses_CourseId",
                table: "Quiz",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempt_AspNetUsers_StudentId",
                table: "QuizAttempt",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempt_Quiz_QuizId",
                table: "QuizAttempt",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Question_QuestionId",
                table: "Response",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentResponse_QuizAttempt_QuizAttemptId",
                table: "StudentResponse",
                column: "QuizAttemptId",
                principalTable: "QuizAttempt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentResponse_Response_ResponseId",
                table: "StudentResponse",
                column: "ResponseId",
                principalTable: "Response",
                principalColumn: "Id");
        }
    }
}
