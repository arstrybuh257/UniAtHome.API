using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class LessonNameChangedToTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Lessons");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Lessons",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "073349fe-b71c-4a80-9c50-3c7ebc4f4499");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "8313e7ff-3ca6-4044-8a01-336809498e05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "5b9eb6e3-7d7e-4335-9832-bfb8622d56f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "742ecdb3-37c1-4eea-8961-96f49c390dc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12aa89a7-dd28-463b-b30a-b688d3c82197", "AQAAAAEAACcQAAAAEAMqjLn7YxgNTNbA5tpNEyTJcH6eXYpxCaSHYeqJNRpEmUBNHrON3Lc7QxBp8FLj6Q==", "749be264-803e-48b0-bc4c-34b55676b2dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b232a11-01ab-40a9-9e33-0ef7dbc6fbd1", "AQAAAAEAACcQAAAAELcE7h7wRU2wAuwB6nzKfUu1mODxuNlaK2/3KDwbgtQEibEvPPKcvgADSAsdRiylEQ==", "b2365c85-bb28-49ec-ba20-c2ec851b1951" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "256e1fed-6e83-4883-b18e-31ac054befd7", "AQAAAAEAACcQAAAAEBwTshmKVFSA59SBgEm9PKGkI/vgB3ZoEZPs3YZx/SsIB0T//z/Bxf/tPkPD2KY0tQ==", "ba21e6ad-12d7-4a33-be72-b4bcc4e099a2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Lessons");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Lessons",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "c46899c2-ce7a-43a2-a98c-475c641be4fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "c04722ad-68b0-4fc3-8cc3-bd1978227555");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "02cc6ab2-612b-421b-9391-cfc1cb3a2698");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "16ea4353-e3b5-4f2e-bf08-53efd96b6e67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "205ba6c7-c52d-422a-ae89-8fab602eeae8", "AQAAAAEAACcQAAAAEA8SR63HT5n3rgmOURCkxxYcrqimM4WowMk3q6Zo7d5BGeWVUxstxareBmpe34B3kg==", "fb520dd7-97ec-4337-9c08-b7eb8645046a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd9a5980-98d2-4808-87b4-f0d590613c6a", "AQAAAAEAACcQAAAAEDB4tglaoaixg8+zfquDokjFsZHBxrVHCGdFMyokagSXkNF7axGj4M9L8xRAYq7R3A==", "af8cf53e-90e6-4fc3-a1e9-59db55e5c63b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c3cff29-498d-4ddf-a792-ba32c93bbbc8", "AQAAAAEAACcQAAAAEKIcAzlUHVJ1AvOvDYeH5SXlHUMpBLjC+ewlRZzTR9tTC1L+Ufiy9xJteSzcxCUyFA==", "b5ffaa97-95bb-440d-bba3-a9b15d591c46" });
        }
    }
}
