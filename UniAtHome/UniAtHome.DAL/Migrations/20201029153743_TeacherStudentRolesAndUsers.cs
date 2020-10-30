using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class TeacherStudentRolesAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "05f078da-c0f6-415d-a931-b4bc6a880e9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "39a0bcee-52b1-403c-80a3-fe923b907e43");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "828A3B02-77C0-45C1-8E97-6ED57711E577", "cf74652c-9eed-4ef8-bcc0-dc23b8d05c3c", "Teacher", "TEACHER" },
                    { "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C", "767d7486-6c43-4dd5-afb1-761f2807447b", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42467bb2-1345-4c70-8d18-f67a058a5c56", "AQAAAAEAACcQAAAAEIJDP1lwuPeiA9WqUc6dhRwnWfIVg8ZFgVmeBrTz5hpTWA8Sb1qZrlUvvxTkRE17LQ==", "ae2c6881-d9b3-4391-b736-ac22d54e36b9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "E8D13331-62AB-463E-A283-6493B68A3622", 0, "f60ea8ff-ac5a-4100-9d76-f61807f58a79", "ihor.juice@gmail.com", false, "Ihor", "Juice", false, null, "ihor.juice@gmail.com", "ihor.juice@gmail.com", "AQAAAAEAACcQAAAAEFBRxqZDXX3M5y754ZRhwqwfNeLPWDXmPiRTwK0ioP2aHo/PNBxOLcy1mE93LiV/Ig==", null, false, "b92d1927-c9a1-43bf-88dc-3790656c1baf", false, "ihor.juice@gmail.com" },
                    { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", 0, "6e4a1080-1ddf-4e94-9482-900e14ae1f6c", "slava.ivanov@gmail.com", false, "Slava", "Ivanov", false, null, "slava.ivanov@gmail.com", "slava.ivanov@gmail.com", "AQAAAAEAACcQAAAAEIx6BA9eN7Vqp3PxwdhCosEPmHI05WsglU15wM5jlDYhH/fuoo0Ue1qcqUE7lXYzpw==", null, false, "3b6c6db4-9e50-4cfb-86c1-750c8439462b", false, "slava.ivanov@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "E8D13331-62AB-463E-A283-6493B68A3622", "828A3B02-77C0-45C1-8E97-6ED57711E577" },
                    { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                column: "UserId",
                value: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B");

            migrationBuilder.InsertData(
                table: "Teachers",
                column: "UserId",
                value: "E8D13331-62AB-463E-A283-6493B68A3622");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "E8D13331-62AB-463E-A283-6493B68A3622", "828A3B02-77C0-45C1-8E97-6ED57711E577" });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "UserId",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f37f55d2-6178-47c8-9495-67b7ee378603", "AQAAAAEAACcQAAAAEL+hSoJh5Ygyq3ysdMLn1XPSd29fB+TbJLri6xmb0tiJ5aH1dFHs8lRvCUSyp7nBHQ==", "ccdf0fe4-31c1-4a53-abf4-5c892f0412f7" });
        }
    }
}
