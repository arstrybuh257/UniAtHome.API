using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class DateTimeOffsetsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateOfCreation",
                table: "UniversityCreateRequests",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "Timetables",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpirationDate",
                table: "RefreshTokens",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "Lessons",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Added",
                table: "Lessons",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Added",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "98ffc78f-539d-443c-9845-8318590fa726");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "342bc4c2-01ee-4ffc-9f30-c7ea2d648626");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "339c44ae-8540-4ab6-bf88-d8bbed2df8de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "8674b9b3-3e49-4568-a89d-3a4f87ba7b01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf485293-3f42-4ccc-8761-c57788947e55", "AQAAAAEAACcQAAAAECmdE6JqAmRUcCyUQBKPvxsffJxL7bWLXm8kAW8fLI0bBP5peguOPI/Tfby6UDPBxQ==", "396a19bd-aa18-4dbf-a177-457760182e09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2aa5ec18-4b58-48bb-a28f-3935d1bfe3ca", "AQAAAAEAACcQAAAAEJA6oVW3DSGNuU9JchsNlG8X9DdagDRTCIoWa9pKeyEBtBE7lsYHieGQGCKjbWv2Gw==", "64b9408b-bbfe-4ce2-909e-199f9f4190ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94bfb6a8-1653-4a53-86c5-cf8be62ff0c3", "AQAAAAEAACcQAAAAEADlwPnG5aa+ykSkz4OQe4xqoqdih3puVXJlmE18p+SDYT5sfwgJElNAsdHM8XMq2A==", "24a47252-13bc-4019-937e-5d5e853b1602" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b10ddf2-2d14-41a5-877c-bf1c8d66500b", "AQAAAAEAACcQAAAAEClA4okqusi36oMy4iJ8ulVCTRYTiuyCdkmVS3LbpJDI3UgWotrXt3Yy8Vwu2MshTA==", "b5a68493-4d1e-4ae2-ac5f-3ad2526a065a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreation",
                table: "UniversityCreateRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Timetables",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Lessons",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Added",
                table: "Lessons",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Added",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "a0b6419c-3653-4f58-98c7-a85c859e12ba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "bb2a12e6-ac16-4955-a80d-d10eb74f44cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "f341109e-eca8-48ad-82c5-b122413e429c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "598000fd-78c4-4108-86a9-ef197ce85879");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e756c2c3-5d76-4446-9a9b-b9a33fa1520b", "AQAAAAEAACcQAAAAEPUhYVrIZtO+/oIBJuzszWKYc0x0saJAlMIuFEk6+zBVj+WO33Zbk0GWFsIsDp1Piw==", "51178ab6-bd01-46bc-ba2e-0ebe4acd7f8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "526ac796-3452-4691-b436-f2de533a383b", "AQAAAAEAACcQAAAAELqjSPcIqxNutJec7O81smavdMOz0QehobXwA9SZLW4f+sxJ7bAyMwEGOidqKPn5vQ==", "ea57cf58-bc7b-4f7c-92ac-a93d98ef9c2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44a9a43b-083e-4a77-9f4d-309a4fd5d9ba", "AQAAAAEAACcQAAAAEKeqpJVRNeQ96v4JxJYo/xtl7+0/qTtOeNtkoV7Fl2/d2ljobcKtVxE/tuF6YJ5I2Q==", "2f90ea2b-42af-4470-9c0d-e62d9b8b792a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e8ad5cb-cb0f-48bb-a940-77031dec4bc5", "AQAAAAEAACcQAAAAEEllom4tBAESRyu30P+mNUzE4v6w+2zAwH5CEkOCkhy+AM7Ui+baaafEux6tX/i1rg==", "006eb7e6-ee3d-4018-998b-bb6f6435a1ae" });
        }
    }
}
