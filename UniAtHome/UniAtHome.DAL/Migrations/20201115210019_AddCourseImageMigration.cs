using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class AddCourseImageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Courses",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "64fd29d3-3977-40ab-8886-0039602ae4c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "18b6dc31-d080-4c5d-9c48-095599da41c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "33852270-ea17-4e3a-93b4-d46e45e7904d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "14e94dcd-cff4-47e6-8a95-67b26a297fe6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6187bb0-e279-4cf2-8197-36125b49737f", "AQAAAAEAACcQAAAAEDTZxhqgGQXAiXUoyhMkXQPjqikxqSIk7zVgpLuP9/LEyAG+KkWUWL6R0W+xr63ytQ==", "ff1f2d7e-204d-4382-946c-ad1330512db7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5947a091-c231-4847-9210-d14779286cad", "AQAAAAEAACcQAAAAEHIdXXVCInIQFmbwX+nLrraH8HiqOY5QhAwhF+Lm7UFUYP5C7ssYR6tyvyGSpqb+cA==", "519d436f-86f9-471f-b8e6-f40d4750ff9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "974fe6ad-b196-4268-ad4f-72ae4b742862", "AQAAAAEAACcQAAAAEFaw5YcblznYga/eY/on9jLNg7eYKXdAF+OgjdCeloGH2ERSPi6Sw1btX7gDwo6f2g==", "65993716-1fde-450a-9c5c-d6ca0d05cf08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54ff0695-37cc-4658-aef7-c1946f8b240e", "AQAAAAEAACcQAAAAEMZjCAyG878vVWhiuArft3gNhGm2Ypw/UoL1IA+fbU3M27YQ1AMYdfjRCKUXqAE/EQ==", "554edb41-76a1-44bd-af87-f050295be934" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Courses");

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
    }
}
