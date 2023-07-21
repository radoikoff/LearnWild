using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWild.Data.Migrations
{
    public partial class AddOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmedOn",
                table: "CourseRegistrations",
                newName: "CompletedOn");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "CourseRegistrations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePaid = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistrations_OrderId",
                table: "CourseRegistrations",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistrations_Orders_OrderId",
                table: "CourseRegistrations",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_Orders_OrderId",
                table: "CourseRegistrations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegistrations_OrderId",
                table: "CourseRegistrations");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CourseRegistrations");

            migrationBuilder.RenameColumn(
                name: "CompletedOn",
                table: "CourseRegistrations",
                newName: "ConfirmedOn");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a806c7be-5b3c-4b69-ae53-8971f082f6ee"),
                column: "ConcurrencyStamp",
                value: "cc515d3d-3d03-4ec4-9d86-65aa3208b268");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf31e446-4f8e-4b70-a201-4b73eb510263"),
                column: "ConcurrencyStamp",
                value: "60ef2bc0-3eac-42d6-995a-4cbddb8553ff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386db847-7c35-4281-a8c6-acd00de18424"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e101ec1-8816-45c1-9472-01caad655a59", "AQAAAAEAACcQAAAAEMVaJbHg6x3t+GkakPEPfC8ZNXyKve3Z2YZb2CANyCA3GvouEAd5BELkM12btZww/Q==", "f639cbc2-9915-4330-b79f-fe616cde7bd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86522b7c-9752-4b0d-a327-59cd8bf8dd62"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be983124-1e77-4db3-849d-62b55ae1ba7e", "AQAAAAEAACcQAAAAECJ5fRRGVqIAl3UiqYhlz0RBKtPE0OzCwsb6Yd08PX0l3IxLHM8yjg+tGU6jwVWj9Q==", "de477f04-67aa-4290-97f3-cbd5c3f0ed39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3dba02e-2e03-4989-81c5-c8288f264c64"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0a05496-34e1-447a-ad32-7f91986444a6", "AQAAAAEAACcQAAAAEH/tYmyCg5fh6SMgp6af5KrmqNHpr1dytmy+tjtPRf9NAqP1EbWcJfxpmRjMMQ0cEw==", "9267e37f-58f7-47be-a53e-f44d9040cd56" });
        }
    }
}
