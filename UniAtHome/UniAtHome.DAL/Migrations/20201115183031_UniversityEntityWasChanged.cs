using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class UniversityEntityWasChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UniversityCreateRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "UniversityCreateRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UniversityShortName",
                table: "UniversityCreateRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Universities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "Universities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Universities",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "86cef86f-46df-4957-90e4-611d5c43d2c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "6453c66d-6c8b-4606-bf3b-4f335e8f06ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "e9bf21ac-3047-4a82-82dd-be613492cf81");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "ae78b7ee-6765-4c2e-b736-e0fd9b23884f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f426e9a3-8086-4c07-bfa4-1af5945db38b", "AQAAAAEAACcQAAAAEMjGvr1kRKtCWdkqzGOtRLnv/MG3jqFK6qCdY8PelZEgJqg1a7/YY3YLq35KXT/UjQ==", "c584f5d3-99df-4212-8a79-19e111060676" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1edae2f9-da72-4d0c-95a7-2d723766fe94", "AQAAAAEAACcQAAAAEOqxyjw210jXGf3CVybvaQWvCjVTympB6AQinfgpgxVreqlUpcBOsNo7GXYFBdXZQw==", "41836bbd-b498-46ef-8568-345da9add493" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d652761b-5758-4900-9855-d45c231142d2", "AQAAAAEAACcQAAAAEExW3o4CmtGSoKgPpQDQg2cIDX8UeMYgBmJ2QLAAPy43oGBXiGBfE7wY8W9g4X/vCQ==", "b4341e50-16c1-434f-9042-6a1184fac189" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "129b2864-f550-49ac-bf5a-cbb10edd7ee6", "AQAAAAEAACcQAAAAEP5u8++F5pT4C2uzW7qCkulekgGlB11sJsqcvLfDIlAD9ZZFiCs8aBkoiy59vg+c2A==", "cdf6fb7f-b5ad-485d-b43d-f4ebf8a5d53e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UniversityCreateRequests");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "UniversityCreateRequests");

            migrationBuilder.DropColumn(
                name: "UniversityShortName",
                table: "UniversityCreateRequests");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Universities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "ce02f73b-7e5e-4bf8-b70a-f13afd494d86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "c92dcab9-cfd7-4055-9c3a-3432a53198c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "944b71b2-a316-411f-bbe3-e99171ab15c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "5dc11c9d-13ae-4332-a228-c3fb61ecb8a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50ac185a-ea76-458a-941b-49ffd20cebb1", "AQAAAAEAACcQAAAAEEFEPVW1yCuZQY4pYAi3rwTIWFroK255Kd8AX+kgnnXAg70JMet6DfVdszS+qS8tfA==", "1374e5fe-1910-4102-8408-c54479ade4ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f372340-d1b1-4d17-a1b0-0359641961bf", "AQAAAAEAACcQAAAAEMWifViQRyszyoave0rP8ASP7Iop5h9XvCDqIQv5o6rt0rG3WHOU5wTt86sd0jlQ7Q==", "de31b772-a574-4fe8-8258-d39c8c34d3e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37c8fa30-95af-4b37-b6b5-f27257547f7e", "AQAAAAEAACcQAAAAECDHlx4npTJVJzfCjGGoUHs6MpOad2hy0Hn9FQa8rdNx5ksh15J8zuBn+wHd88cAlQ==", "923928b1-a8b4-4b37-aa2a-eeebdacc263b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "921c6b13-cb7f-435a-9446-2493397e433e", "AQAAAAEAACcQAAAAEE0mDVXE48XvTHz9gtyM3eDG3TiOvrYc9rDG8iEWyK1crjGB+QFsGR4sWmh5jFta0A==", "3d4507db-dde5-40fd-a88d-4fa2132fbe30" });
        }
    }
}
