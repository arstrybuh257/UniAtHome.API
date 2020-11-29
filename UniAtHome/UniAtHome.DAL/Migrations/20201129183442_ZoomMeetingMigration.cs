using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class ZoomMeetingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZoomMeetingGroupId",
                table: "Timetables",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZoomMeetingLessonId",
                table: "Timetables",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZoomMeetings",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    ZoomId = table.Column<long>(nullable: false),
                    JoinUrl = table.Column<string>(nullable: true),
                    StartUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoomMeetings", x => new { x.GroupId, x.LessonId });
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "d9bebf94-2868-4d13-a7c5-1201e7457536");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "0160153a-85b7-4f55-87e9-ec2e727a4340");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "89908527-54a0-41dd-b6df-c27a8c47de72");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "0c7ab657-edb0-4783-b242-caabdbc60b89");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7e241fb-1c96-43c2-b9c1-dd25559db397", "AQAAAAEAACcQAAAAEGmrqiCh1q/++EcpQ/bkBqCObTWvr6HXw3Li7kP7c5+gf40ii9XULb0iscvAHHHVsQ==", "87954b95-323f-49a8-a1d9-e96c0ea5df48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d7f097d-4b94-48cf-b59c-396115b81e14", "AQAAAAEAACcQAAAAEO6YUVkjsDi16kuVj7XlXOokqY01kmeFVGBHdSIKV6ex21OiwfAj1tQqQ/PpC3FZRw==", "bef33a41-8e01-429f-926c-81eb7c233708" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36e2405b-2e43-4d9e-89bd-22106270734a", "AQAAAAEAACcQAAAAEDRfXei84Ecb0+mlRZa2vVvcK5tDW2uIzZogJl+eum7uxdjqyhoxsrH4lFUlYjEWtQ==", "626df349-f8d2-4c3f-aeec-322740d0f86e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11bff554-de98-4a60-8f3f-0f789516feb8", "AQAAAAEAACcQAAAAEOYDiQJX04C8O2XgZNWSDV6GVPn0D/pj28hW1a9kbd38GFtOvrVuZwmu+b4sFUCOug==", "38ed5454-8bf6-44ed-b7af-4ab401590305" });

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_ZoomMeetingGroupId_ZoomMeetingLessonId",
                table: "Timetables",
                columns: new[] { "ZoomMeetingGroupId", "ZoomMeetingLessonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Timetables_ZoomMeetings_ZoomMeetingGroupId_ZoomMeetingLessonId",
                table: "Timetables",
                columns: new[] { "ZoomMeetingGroupId", "ZoomMeetingLessonId" },
                principalTable: "ZoomMeetings",
                principalColumns: new[] { "GroupId", "LessonId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetables_ZoomMeetings_ZoomMeetingGroupId_ZoomMeetingLessonId",
                table: "Timetables");

            migrationBuilder.DropTable(
                name: "ZoomMeetings");

            migrationBuilder.DropIndex(
                name: "IX_Timetables_ZoomMeetingGroupId_ZoomMeetingLessonId",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "ZoomMeetingGroupId",
                table: "Timetables");

            migrationBuilder.DropColumn(
                name: "ZoomMeetingLessonId",
                table: "Timetables");

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
    }
}
