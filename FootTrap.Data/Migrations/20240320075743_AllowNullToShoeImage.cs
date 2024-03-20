using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootTrap.Data.Migrations
{
    public partial class AllowNullToShoeImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShoeUrlImage",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "e67b45fd-f13a-450d-a3b3-e3c1a2c5394e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "8ce00e9b-8a2e-4a99-86a1-232878dbaf69");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e005444-cb2b-4a47-87ba-4fd4d35f96e3", "AQAAAAEAACcQAAAAEEP3Jp0Nh8rYMK5Qk3pzBdg30WN+wWytjab+R2sa/KPFM7isD1suI8qaf5QbXCzhiA==", "4dfa9d46-2af7-4834-94bd-f7ba269ddfb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f3df805-e00f-4931-afe6-353e26966e01", "AQAAAAEAACcQAAAAEDaERB9iR6DckG/5b/j2ljCrM6JQoJSLtq4Fw0ayUdsXP/ydgaoOriFkNXMCBWGR1A==", "8b2b7720-cdfa-4e49-a066-c7b8f368c6dc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShoeUrlImage",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "914c9346-4a95-4cd7-a16b-0f5a82f7b348");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "4ec98a1a-b777-49b1-b766-dffa08c7f98f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "945d8178-b381-4b7e-ae70-b373510c1ac7", "AQAAAAEAACcQAAAAEN2Nwn2luML4M2b0ZZyTrwsBGsKIZ/cFyp0ma3LrpGpWPPeTlzs6J2cD7+TjCcIfWQ==", "aece7d2f-24c2-423d-a470-a19ff5f3b048" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6cecf90-54a0-4cd6-bb86-8fc76b35f7a4", "AQAAAAEAACcQAAAAEKLFnm8SYzrtg3Zr33gxYtO6GH6vXGUHdGSE+767Mn9qm8m2ubS57BFYYTPLiXTgNw==", "d9bdf652-d26b-4b7a-9166-3fae6a639b2f" });
        }
    }
}
