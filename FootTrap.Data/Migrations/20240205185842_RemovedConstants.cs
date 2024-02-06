using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootTrap.Data.Migrations
{
    public partial class RemovedConstants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecurityCode",
                table: "Payments",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecurityCode",
                table: "Payments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

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
        }
    }
}
