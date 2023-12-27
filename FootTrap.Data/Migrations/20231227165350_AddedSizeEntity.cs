using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootTrap.Data.Migrations
{
    public partial class AddedSizeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "8665834f-e6d7-42d8-9452-f408b7797693");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "7b3b50be-dde6-4dec-9c33-cbd02850539a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5a2920d-4311-44bf-a4bd-868c87464466", "AQAAAAEAACcQAAAAEL1lRcwOFUikry2ia7i1cuiGinOWKty0zi7ta6sQyU1SKjXnZ5sXPVIrAysrUzMN/g==", "23a36b51-4975-4917-b3c5-ee7ca7a06679" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6ff751d-ac5d-4043-8ae0-a6aba7a6d9d0", "AQAAAAEAACcQAAAAEBKvIau2ftxq/8oNlSGdRV9flJie+FkKtEl8L3b8a0N/JK8ctCPsj0+yv0j7ccfb/Q==", "b67139ca-69e6-4104-81e0-0b6e34c74c17" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 36 },
                    { 2, 37 },
                    { 3, 38 },
                    { 4, 39 },
                    { 5, 40 },
                    { 6, 41 },
                    { 7, 42 },
                    { 8, 43 },
                    { 9, 44 },
                    { 10, 45 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_SizeId",
                table: "Shoes",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Sizes_SizeId",
                table: "Shoes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Sizes_SizeId",
                table: "Shoes");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_SizeId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Shoes");

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
    }
}
