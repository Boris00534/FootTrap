using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootTrap.Data.Migrations
{
    public partial class ChangedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Sizes_SizeId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_SizeId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Shoes");

            migrationBuilder.CreateTable(
                name: "SizeShoe",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ShoeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeShoe", x => new { x.SizeId, x.ShoeId });
                    table.ForeignKey(
                        name: "FK_SizeShoe_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SizeShoe_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "13404c4c-d0e3-47e3-9cb8-342f26633736");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "10abd63c-7e9a-43a7-a438-58912458f252");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b484613-9839-41d3-a532-3893ca7f2773", "AQAAAAEAACcQAAAAELokVEWlmJDZKYakZuzKbYylyo9SaH/DTcOP3V43pUL4pa7dyw4xqO1Ru3ZAzgkMfg==", "9493c400-ceda-4469-aa20-e907f4c4b84f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72e86b3d-2167-4369-bfe5-1fe2763c0741", "AQAAAAEAACcQAAAAEHAeHuFali74M1i2OH/WHq9mOsDWNucITn90QeTKN9LSxYJdro8iOmj4LMyk8avFCg==", "bb459876-d80b-4ec5-bb33-cf7d7ef56d4e" });

            migrationBuilder.CreateIndex(
                name: "IX_SizeShoe_ShoeId",
                table: "SizeShoe",
                column: "ShoeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SizeShoe");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
