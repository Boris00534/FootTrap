using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootTrap.Data.Migrations
{
    public partial class ChangedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "de05c997-0353-4e64-bc6b-f8289a4ed846");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "237f6ed9-9c4e-4ce2-82e3-8765d87640eb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68da6814-4621-4c43-bc2c-354605f7ca78", "AQAAAAEAACcQAAAAEAdcswpgdtJ1iES8NfJP7ow1ayeqb+C+6gWGY4VYcVk7cosveltddttUO1LspkUtVw==", "a6b52950-9de1-45d8-b241-698e5e62475d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cc1b76c-b5f6-4923-b696-d44f7b54b79f", "AQAAAAEAACcQAAAAEOkDhJ2VF9JTBqR12r8NmJv9jUHNqLCn8UEKRT94M1NiklslhloJkBlN/dEguYKpYw==", "003c2d37-5728-4c2a-8751-282ac0d02722" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "ac7a3e97-7a45-41e7-9fd3-7bc95caa4263");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "51293030-a3ca-4b62-b6e8-f52d6ff1eadc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e37bb0ed-f02f-4998-9685-cefc47769afe", "AQAAAAEAACcQAAAAEK0O1IoAexVBmBuu9YHunwwvcLSFFBgEro5qKsxcVOJqzpR5MUydui7tm82xOUbQHg==", "d1627c3a-7781-40fe-b78e-890026dfa126" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "811f2328-8789-483e-b22f-2953af3746a1", "AQAAAAEAACcQAAAAEFvyj2JaTGJcOnG0IxqySonS71Tgs6N+VD6ZDyJrHUvWKu70X1pNxkNPbxWq5j/2VA==", "93236fc3-e315-4389-ba83-1f67711693d2" });
        }
    }
}
