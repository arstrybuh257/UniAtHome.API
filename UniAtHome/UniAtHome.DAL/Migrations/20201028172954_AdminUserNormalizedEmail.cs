using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class AdminUserNormalizedEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "2ecdd19c-98b4-4a4c-bec0-827d5c5cda3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "1171a711-b5a7-4b8c-ba3f-36cbfb2823c0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f37f55d2-6178-47c8-9495-67b7ee378603", "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEL+hSoJh5Ygyq3ysdMLn1XPSd29fB+TbJLri6xmb0tiJ5aH1dFHs8lRvCUSyp7nBHQ==", "ccdf0fe4-31c1-4a53-abf4-5c892f0412f7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "322249d1-712d-47be-8a2f-45d8736a9aa0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "b15d645b-42ce-448c-9070-ae202f7ab2f5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ad7127-7531-4ac4-aaea-592249f1cd89", null, null, "AQAAAAEAACcQAAAAEISHy05Q0/LB3OCBMnnLJqKJI7XWwqPPQVbnjCd7bba3+munRiDZ/oGWTF3oRlRc2Q==", "790fd498-0d7b-4328-8c7f-d5419b17169c" });
        }
    }
}
