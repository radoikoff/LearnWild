using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWild.Data.Migrations
{
    public partial class AddMorePriceFieldsToOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Orders",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubtotalPrice",
                table: "Orders",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SubtotalPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "77337c61-141a-4605-8951-e24d4072bce4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "5ead9893-6a62-4546-9477-c6282928952c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3607e946-e3a3-4d15-a1fd-10639b26c25f", "AQAAAAEAACcQAAAAEB5sz1Zj/VBarjfkQr3aFvB1Knga0+FRkWjlxD4sYKbBLxpNuaU3sCoTW/kc4mggKw==", "2abc1b94-b5cb-48ab-bb53-d841e403af2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b712b5b7-c44a-4daa-a4d4-d1f3e096ea2d", "AQAAAAEAACcQAAAAEEMUhBTIbj3zKbP68PU3fD9VrK7yuzKjxwf3CO6uCzzzySAPKCiaGNXSwfccBJLIEQ==", "96a62edf-32cd-4893-969b-e757e37dd4a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4f76c4f-fe5a-477c-ad1b-a49ad15bc236", "AQAAAAEAACcQAAAAEL4vJt8z+QqEaHtFaQDAYcTxhDUixod/5+QhoOd4svsaW4wpNn1lTmIxQqOk8o1WXQ==", "eb269a9e-6911-4975-8e28-5b4543bd5fef" });
        }
    }
}
