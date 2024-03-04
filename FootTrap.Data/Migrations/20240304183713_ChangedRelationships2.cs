using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootTrap.Data.Migrations
{
    public partial class ChangedRelationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "cd5a1fc9-3c06-420c-96d3-09e86958f4ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "aa583389-9d41-476b-9eb4-74e7234ccc09");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dfc643d-155a-45b1-a551-22e656298907", "AQAAAAEAACcQAAAAEH/ng+ZcY9oHMLzyrxEDEgtJHSS0XtpwgFdHSfd3PU2z6DE7kunixBpOjoupYdJhMA==", "c352de4e-fec3-4db0-bcb2-5aab18c61cb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74bd5953-ca3d-4d41-8235-4af8057fa21c", "AQAAAAEAACcQAAAAEI6V/eQLFuAn/S+ZkIz5HyeAKcCw3SDQcBpqz2qAWOILp43M/dPfBpSjBlncJ/jbdw==", "456c618d-0f4f-4321-88d8-5800cd4b236b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "9ee4d1a2-4064-4735-992e-24c4f27a7ad0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "d2e43f77-8df1-4c22-b73e-b2374401613f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb51c3d1-3873-4eb6-b566-cc14e992ca95", "AQAAAAEAACcQAAAAEJsSGGtG+o1+x9I5uFrtIU2fK6NmHPYxmR0Dx5mwysFd8u/jFG2OOZNIlfnVaKhqsA==", "d6aa44ff-5f59-454a-9c63-84f9e437368c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2949f2a1-90ed-4639-abe2-1253c1da1125", "AQAAAAEAACcQAAAAEJgdnffzB04rXVaPDYJi11zLVNCXLjvzVF+/izcpVu43EZ7cI50IROM7nv5j7mRM9A==", "d07c6f75-edb7-4762-bf66-4c7cca0556bd" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
