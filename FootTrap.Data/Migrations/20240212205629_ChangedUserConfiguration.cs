using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootTrap.Data.Migrations
{
    public partial class ChangedUserConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39133354-2848-4a57-9f54-59680d7d19ec", "GEORGIIVANOV@ABV.BG", "AQAAAAEAACcQAAAAEFIG6xsIqR9VBOAW2IUTij33xtRktsVj1VEI/2ChGjLpW+0lOiyYYyS5JrTxdOkLLw==", "5132bb8f-ed5e-47f0-808e-4afe3e094eca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "4208327a-bcd9-4924-9452-65dc6b4cfd75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "40fa4c4f-1636-4a58-a018-f94fd559c6a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03588cb1-f306-4474-bd8a-05306bed948e", "AQAAAAEAACcQAAAAELTS6MdY0/I9XsSYrtmR9XRs+f0NJqDX9/6tL5ZekTK500tPN7zhz0Ak9HON071iIw==", "5faeaeb6-c4c2-4d10-9dce-36729a2331dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9036850-ae55-4a8c-bf37-de43774d909a", "GEORGIIVAONV@ABV.BG", "AQAAAAEAACcQAAAAEJPPkmlxDrwGKdgdlF6N5cggd0cTwMQBywubo0FbuXxohP0tvkp9VHlqoHwb1bL3ng==", "0fbead0e-89e4-4cdb-9322-e5dd65405cc0" });
        }
    }
}
