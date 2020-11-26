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
                value: "16c526d5-e57c-4dc8-aedc-aa35ea406671");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "fba219ad-da42-4d1d-b350-aa04ff3aee5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "76bdc42c-1bf7-4cc0-ae7d-90706237df9b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "e4ccf6dc-2ab2-4e82-aa63-82c2e0cecd27");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66a9ba33-f31b-49e3-8eb7-fc80df5c9849", "AQAAAAEAACcQAAAAEOx/7soXtOw5kbMBNp8WxU0WuC8QdbB5YO43WfZLsSCazQ7FTej/tfILxVdVsyj5pw==", "c9e739b4-915f-47b8-853b-59f5536e1cc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5c73d36-25cc-493c-90e1-382017515ec7", "AQAAAAEAACcQAAAAEJJbS2J9N0Yoz0FZX/tR8ZSXWdldPnH+YhdP7O+Zm98Ysq8jaI6X9FS1s6K9OTyMEQ==", "f3966896-bebc-4bbe-9b72-e15e121897cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6e68273-5276-4331-a1aa-43544126edd3", "AQAAAAEAACcQAAAAEGXbqgKZjiERmYgaHLgIJJbudvDRwY7FYWM4d+XIVpO+446qmcfGStTVPxFA1EcMSg==", "fbf53fac-f6ee-4549-887c-97e41bf2056a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22bea555-c488-46b3-97f7-05fb7df013f6", "AQAAAAEAACcQAAAAEDXY4KV0ZsJPq0uvx4kmO2sd3b5GMNRE1R7byJ74GA8ZKjtpC46amVyEDSAZp/qy2A==", "dfdd06d7-2627-4024-ae42-0c3f2195edd2" });
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
    }
}
