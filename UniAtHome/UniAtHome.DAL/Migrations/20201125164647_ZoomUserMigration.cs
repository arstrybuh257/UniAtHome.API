using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class ZoomUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZoomUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoomUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ZoomUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "997a03d5-eedc-400e-bd99-dd10447a7941");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "a5cf99a8-6af5-4346-ae71-4e55d42c1d97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "d1e0bc4d-4038-45ea-8bb2-6f751d6c0096");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "9b269604-eabe-4a4a-8d34-529c70011f58");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a04f6aba-b98c-40bd-b518-94739211639a", "AQAAAAEAACcQAAAAEA35SbEFEFmOzEDeCW5JzSrD5i8NrVQprtkgKqY8r/qVN9Ky+4ZR9UDTdspXiiqkCA==", "be4b5a0c-f9c9-47a6-aeb7-7b58e9273d84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e7b6a9a-1145-4d07-bfe8-27d3d0d296f9", "AQAAAAEAACcQAAAAEO8gGHvTDhP4diiX/ZPjKyB4c6fT9ZqcBkpGtVPZRjSmjlYOVoWQhshXbOrlgcPG3w==", "da7e5de5-f380-4ac7-897e-b0534c0a5b9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c655175-a575-42bc-a3e9-1413eb79514c", "AQAAAAEAACcQAAAAED+z3EZPMdEMnOksNep4GB8AYgk4Mp4h0h0qNHFPyDu8LAuLVcmKpx3I3ZnWrl1WFw==", "51959a3f-bdf9-4699-bde5-87944bd354c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "031b261b-0181-4abb-a9f2-c99e7bc9fdde", "AQAAAAEAACcQAAAAEJre8w3UOxZKuWd0voSmbQk02t04rTlUyTgsgbzri2ix/mF5fEQP1034lHhRJDLPKw==", "6d497530-6dd0-4233-9e4b-440157486820" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZoomUsers");

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
