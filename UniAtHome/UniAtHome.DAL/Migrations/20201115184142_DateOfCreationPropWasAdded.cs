using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class DateOfCreationPropWasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "UniversityCreateRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "09bde4ec-96ff-4b79-8490-691f654362bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "ac4a65ac-9b7f-4a8c-ab4a-397d88ee6efe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "ad325ab8-714a-4300-8038-3fda61bb3dd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "9824fed2-8438-4185-91b1-d7db3819e3ad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b324a9e-1b93-4224-a742-0aa7524820db", "AQAAAAEAACcQAAAAEKxebW38ih/rm1wWGx0ANimPnzESJKGo+wdcyar/SuGltie69fiP9est1tm5VMBnRQ==", "501471f4-001d-494b-a8f0-66d066022188" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "025b94be-44a7-4de6-a733-1c3f60254591", "AQAAAAEAACcQAAAAEGH3rolzQNAUMzPrs4gl5HnlYvUquNphuudPn7rKDz2ygvpnrJ7eXEQmHdmqthEZjw==", "a77e8e80-bbc8-439b-a719-ec1fc852492c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17e59a4e-1811-4981-a7e9-62d2512596f7", "AQAAAAEAACcQAAAAELkZB/P6TIkW69pQjEcwj/fWwbShfr0RGWzlBX9TOJ1RFfCuQxU8TeT7S7dTkCWT4g==", "313d348f-8c46-41b4-b752-7bdf7310dd2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e51c49d-b822-4e37-aeba-74a0fd35f607", "AQAAAAEAACcQAAAAEKy0cqNSyCY18UFr3Hl66eoyRbzeFUuj5FcEPrqnON1JzbaTxq5rw1kuV1VxgiTjwQ==", "77a5ce88-e542-48d5-896a-71ba15ced9a4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "UniversityCreateRequests");

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
    }
}
