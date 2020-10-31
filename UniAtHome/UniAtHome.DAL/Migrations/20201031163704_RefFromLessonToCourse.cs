using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class RefFromLessonToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetables_Lessons_LessonId",
                table: "Timetables");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Lessons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "c46899c2-ce7a-43a2-a98c-475c641be4fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "c04722ad-68b0-4fc3-8cc3-bd1978227555");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "02cc6ab2-612b-421b-9391-cfc1cb3a2698");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "16ea4353-e3b5-4f2e-bf08-53efd96b6e67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "205ba6c7-c52d-422a-ae89-8fab602eeae8", "AQAAAAEAACcQAAAAEA8SR63HT5n3rgmOURCkxxYcrqimM4WowMk3q6Zo7d5BGeWVUxstxareBmpe34B3kg==", "fb520dd7-97ec-4337-9c08-b7eb8645046a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd9a5980-98d2-4808-87b4-f0d590613c6a", "AQAAAAEAACcQAAAAEDB4tglaoaixg8+zfquDokjFsZHBxrVHCGdFMyokagSXkNF7axGj4M9L8xRAYq7R3A==", "af8cf53e-90e6-4fc3-a1e9-59db55e5c63b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c3cff29-498d-4ddf-a792-ba32c93bbbc8", "AQAAAAEAACcQAAAAEKIcAzlUHVJ1AvOvDYeH5SXlHUMpBLjC+ewlRZzTR9tTC1L+Ufiy9xJteSzcxCUyFA==", "b5ffaa97-95bb-440d-bba3-a9b15d591c46" });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Timetables_Lessons_LessonId",
                table: "Timetables",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Timetables_Lessons_LessonId",
                table: "Timetables");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Lessons");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "05f078da-c0f6-415d-a931-b4bc6a880e9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "767d7486-6c43-4dd5-afb1-761f2807447b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "cf74652c-9eed-4ef8-bcc0-dc23b8d05c3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "39a0bcee-52b1-403c-80a3-fe923b907e43");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42467bb2-1345-4c70-8d18-f67a058a5c56", "AQAAAAEAACcQAAAAEIJDP1lwuPeiA9WqUc6dhRwnWfIVg8ZFgVmeBrTz5hpTWA8Sb1qZrlUvvxTkRE17LQ==", "ae2c6881-d9b3-4391-b736-ac22d54e36b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e4a1080-1ddf-4e94-9482-900e14ae1f6c", "AQAAAAEAACcQAAAAEIx6BA9eN7Vqp3PxwdhCosEPmHI05WsglU15wM5jlDYhH/fuoo0Ue1qcqUE7lXYzpw==", "3b6c6db4-9e50-4cfb-86c1-750c8439462b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f60ea8ff-ac5a-4100-9d76-f61807f58a79", "AQAAAAEAACcQAAAAEFBRxqZDXX3M5y754ZRhwqwfNeLPWDXmPiRTwK0ioP2aHo/PNBxOLcy1mE93LiV/Ig==", "b92d1927-c9a1-43bf-88dc-3790656c1baf" });

            migrationBuilder.AddForeignKey(
                name: "FK_Timetables_Lessons_LessonId",
                table: "Timetables",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
