using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class TestsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DurationMinutes = table.Column<int>(nullable: false),
                    ShuffleQuestions = table.Column<bool>(nullable: false),
                    ShuffleVariants = table.Column<bool>(nullable: false),
                    AttemptsAllowed = table.Column<int>(nullable: false),
                    MaxMark = table.Column<float>(nullable: false),
                    LessonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tests_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Checkbox = table.Column<bool>(nullable: false),
                    Weight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    TimetableGroupId = table.Column<int>(nullable: true),
                    TimetableLessonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSchedules_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestSchedules_Timetables_TimetableGroupId_TimetableLessonId",
                        columns: x => new { x.TimetableGroupId, x.TimetableLessonId },
                        principalTable: "Timetables",
                        principalColumns: new[] { "GroupId", "LessonId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestAnswerVariants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnswerVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAnswerVariants_TestQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "TestQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "d2a02aca-7ae6-4974-bfc9-55a5ef2325b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "4c909024-9273-479a-949c-cd683886d52c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "18e622d3-ede6-432d-883c-4eff127bd5a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "a47c7989-6422-4641-9311-56e227be579c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a9e72bc-65b8-4713-85a1-d234b52bf25d", "AQAAAAEAACcQAAAAEKlBUMO5UDscOeYX7eKk992iOQI8a91SMKz3H+JF26lLYaOKI9g5hXHhSINV4MZgiA==", "81f1135f-95c0-44cf-829c-8ea2fd46b066" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68ded56a-65ca-4223-a87f-d44c0e76b7d1", "AQAAAAEAACcQAAAAEH+Zof6deexfl4Bv1TMlsUQbxhN/D2Rj/0KfmV5GwKApytHt2T7+Y5CMMQT+eLsTHw==", "3a7fef63-414c-4006-af0f-0fa3c90ceb1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c68a3af-f63a-4c31-bbce-c152f3e24cfa", "AQAAAAEAACcQAAAAEG7mR6VgCkQ1v7neZdzyPtmww82DUhqIV6FupuRG76TdNCG8uQb+KJPAtjTCsiVugw==", "ea7de213-909a-47f9-b862-03a23b0afc36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22bf3dec-c073-4f7a-bcf4-e7c589c4eb0a", "AQAAAAEAACcQAAAAEADsy2NlFI55YLd6pJchzbMzKsSRfJhtvPuqxFQBxdQhpq5AEgSOXxqn5EGzal69nw==", "3d572056-8272-4bd5-bf58-21a15707727b" });

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswerVariants_QuestionId",
                table: "TestAnswerVariants",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_TestId",
                table: "TestQuestions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CourseId",
                table: "Tests",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_LessonId",
                table: "Tests",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSchedules_TestId",
                table: "TestSchedules",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSchedules_TimetableGroupId_TimetableLessonId",
                table: "TestSchedules",
                columns: new[] { "TimetableGroupId", "TimetableLessonId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestAnswerVariants");

            migrationBuilder.DropTable(
                name: "TestSchedules");

            migrationBuilder.DropTable(
                name: "TestQuestions");

            migrationBuilder.DropTable(
                name: "Tests");

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
        }
    }
}
