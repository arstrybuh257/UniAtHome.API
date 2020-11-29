using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class CourseSeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "df7040e0-b7e3-48d5-908d-1e82bd5bf27f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "8b58b055-3471-4fc3-823f-ef0951cf4090");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "45cd7ea1-96a6-49d6-ac3a-18eedf37f35f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "fec35770-142b-4dfd-a501-c6e50e13e1ae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ace622d-cf4b-469e-8db0-6a0c9c4b8680", "AQAAAAEAACcQAAAAEKok3kM2qeFDhYghrXUr8+Q4OsWOUB3d9VSXBKLaCI4GgMOpQnec9J/P3K9eIvRRMQ==", "757045d9-c3d4-44c5-b68d-696de0d8b9c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf27775c-3d5d-44f9-93e5-0eab46451ac6", "AQAAAAEAACcQAAAAEJgQZ2Wjom+SwlFkWcMWGmUm3uvg8w4GtyTRVvO+IjaGAYA4FPGYd0xInIcQYJQTeQ==", "1846fc07-59bb-4e0f-8f9f-b467eb77e0c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d40d9302-a089-40b9-a3f6-38dfc861b7be", "AQAAAAEAACcQAAAAEFA8mOElZNjWbtpanEubYD/docorgeASYNMblnWxiX2eGPVpQwkP/N6JPHZUR4CgAw==", "42248662-0976-4df9-a085-e41bf470d37a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a406f265-8e3a-4138-8992-c1b4d1faf06f", "AQAAAAEAACcQAAAAEGZAMyzj06YeTNI2ncOcrT2uu3IQbFhiKjq2GtSfF1yTi0s5KTxkL+MzE9wEUvIceA==", "6d43cbc6-d432-4c63-8b14-ae9187a0a889" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Added", "Description", "ImagePath", "Modified", "Name", "UniversityId" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Teaching how to write clean code", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Code analysis and refactoring", 1 });

            migrationBuilder.InsertData(
                table: "CourseMembers",
                columns: new[] { "Id", "CourseId", "TeacherId" },
                values: new object[] { 1, 1, "E8D13331-62AB-463E-A283-6493B68A3622" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Added", "CourseId", "Description", "Modified", "Title" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Java does not rule, however we have to pretend it does", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learning Java" });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "CourseMemberId", "Name" },
                values: new object[] { 1, 1, "SE-18-6" });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "StudentId", "GroupId" },
                values: new object[] { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentGroups",
                keyColumns: new[] { "StudentId", "GroupId" },
                keyValues: new object[] { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", 1 });

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

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
        }
    }
}
