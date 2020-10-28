using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class AdminRolesAndUserSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2AEFE1C5-C5F0-4399-8FB8-420813567554", "322249d1-712d-47be-8a2f-45d8736a9aa0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99DA7670-5471-414F-834E-9B3A6B6C8F6F", "b15d645b-42ce-448c-9070-ae202f7ab2f5", "UniversityAdmin", "UNIVERSITYADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00CA41A9-C962-4230-937E-D5F54772C062", 0, "58ad7127-7531-4ac4-aaea-592249f1cd89", "admin@gmail.com", false, "Admin", "Adminovich", false, null, null, null, "AQAAAAEAACcQAAAAEISHy05Q0/LB3OCBMnnLJqKJI7XWwqPPQVbnjCd7bba3+munRiDZ/oGWTF3oRlRc2Q==", null, false, "790fd498-0d7b-4328-8c7f-d5419b17169c", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "00CA41A9-C962-4230-937E-D5F54772C062", "2AEFE1C5-C5F0-4399-8FB8-420813567554" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00CA41A9-C962-4230-937E-D5F54772C062", "2AEFE1C5-C5F0-4399-8FB8-420813567554" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062");
        }
    }
}
