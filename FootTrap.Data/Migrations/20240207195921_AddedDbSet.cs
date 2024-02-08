using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootTrap.Data.Migrations
{
    public partial class AddedDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeShoe_Shoes_ShoeId",
                table: "SizeShoe");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeShoe_Sizes_SizeId",
                table: "SizeShoe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeShoe",
                table: "SizeShoe");

            migrationBuilder.RenameTable(
                name: "SizeShoe",
                newName: "SizeShoes");

            migrationBuilder.RenameIndex(
                name: "IX_SizeShoe_ShoeId",
                table: "SizeShoes",
                newName: "IX_SizeShoes_ShoeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeShoes",
                table: "SizeShoes",
                columns: new[] { "SizeId", "ShoeId" });

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9036850-ae55-4a8c-bf37-de43774d909a", "AQAAAAEAACcQAAAAEJPPkmlxDrwGKdgdlF6N5cggd0cTwMQBywubo0FbuXxohP0tvkp9VHlqoHwb1bL3ng==", "0fbead0e-89e4-4cdb-9322-e5dd65405cc0" });

            migrationBuilder.AddForeignKey(
                name: "FK_SizeShoes_Shoes_ShoeId",
                table: "SizeShoes",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeShoes_Sizes_SizeId",
                table: "SizeShoes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeShoes_Shoes_ShoeId",
                table: "SizeShoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeShoes_Sizes_SizeId",
                table: "SizeShoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeShoes",
                table: "SizeShoes");

            migrationBuilder.RenameTable(
                name: "SizeShoes",
                newName: "SizeShoe");

            migrationBuilder.RenameIndex(
                name: "IX_SizeShoes_ShoeId",
                table: "SizeShoe",
                newName: "IX_SizeShoe_ShoeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeShoe",
                table: "SizeShoe",
                columns: new[] { "SizeId", "ShoeId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5a35b7-23c2-4d95-b772-4b91609e65e7",
                column: "ConcurrencyStamp",
                value: "8a7ab056-56fb-457d-b8c0-2f442b3cc2a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599457c1-5737-4071-acbe-9f2cc064e41d",
                column: "ConcurrencyStamp",
                value: "1461ea49-3c8d-4100-a5cc-8e78eb40dddc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0eef1000-e7a0-4a14-9f7a-4c7e7ad324d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25078187-756e-4746-8759-cab75dcaab40", "AQAAAAEAACcQAAAAEAhEPVlJM3LC3S4HOFyjkYbiT3RdNlBrIx273Dk960vwhZ5dMPmpEpkzIJs3IJQixw==", "a5df84d5-e579-4b82-92ce-0d1e901f1998" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2007b9-1919-4382-983f-a583d47b9040",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee7c4af5-91bd-4d48-b779-9768ff458d0e", "AQAAAAEAACcQAAAAECCUnBNw52KkqudYyIxUXBIzgq9s3WgKRLOYTRSKgPg7/eQqN3moiNMlfTH4WjI//w==", "41271517-cd19-4d15-966e-3a594a6657a7" });

            migrationBuilder.AddForeignKey(
                name: "FK_SizeShoe_Shoes_ShoeId",
                table: "SizeShoe",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeShoe_Sizes_SizeId",
                table: "SizeShoe",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
