using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWild.Data.Migrations
{
    public partial class AddedFileNameAndMimeTypeToResourseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Resources",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "Resources",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "69c8a786-cf28-47bb-b99e-1004860893fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "8daa5c86-ac80-4589-9480-441d1ff4952b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9fd769c-8a28-44b7-96f4-cc43a3a00242", "AQAAAAEAACcQAAAAEFHeDbfR2mF6OqaG9bV3Q8cdv1bQhnuVtAnlwRhDaAyWZdJsocZ4LDreWvFmDZlCpA==", "9442d3fb-a434-4597-9ab0-e10be533d2b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9c49776-72c7-4f01-ad73-1ba262086379", "AQAAAAEAACcQAAAAEH/jhqijUX+Re2fc2K20Lfm5YTsMjtGhY2LVa/Q3ht2emydjumbkn7bePOrvcdZ/FA==", "fd9d478e-abac-4431-a941-8b37a9b0aca0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa60d1e7-2b10-4c80-ab8a-15e0b46a5b12", "AQAAAAEAACcQAAAAEGkG4PgeFJ4d0F6zoA+kpXNvdbb7w+rGl4F78zhh0bDFAMEW5RWPPFwMwk0bDNvQsA==", "6004162a-676a-45c7-bf4c-1418f9d3227c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "Resources");

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
        }
    }
}
