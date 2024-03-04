using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootTrap.Data.Migrations
{
    public partial class ChangedRelatinships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "a91974f7-3c7b-4d74-9f49-49dbb6d1c0ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "f64c2b60-ef77-4529-810f-b350687dab7c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1113eb3-cf72-4790-b1b5-200b84ad747b", "AQAAAAEAACcQAAAAELjW/jQEzhCichIA9+hh0iVGgkIjT2/JCZaQsiU+JihgA/idDER1S3hokRkCZOGEfQ==", "ff4c9879-9fc7-476d-b805-50db146d268c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39133354-2848-4a57-9f54-59680d7d19ec", "AQAAAAEAACcQAAAAEFIG6xsIqR9VBOAW2IUTij33xtRktsVj1VEI/2ChGjLpW+0lOiyYYyS5JrTxdOkLLw==", "5132bb8f-ed5e-47f0-808e-4afe3e094eca" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
