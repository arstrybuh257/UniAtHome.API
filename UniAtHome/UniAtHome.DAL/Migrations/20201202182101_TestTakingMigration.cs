using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class TestTakingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "BeginTime",
                table: "TestSchedules",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndTime",
                table: "TestSchedules",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "TestAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: false),
                    BeginTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAttempts_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestAttempts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestAnsweredQuestions",
                columns: table => new
                {
                    AttempId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    AttemptId = table.Column<int>(nullable: true),
                    AnswerVariantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnsweredQuestions", x => new { x.AttempId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_TestAnsweredQuestions_TestAnswerVariants_AnswerVariantId",
                        column: x => x.AnswerVariantId,
                        principalTable: "TestAnswerVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestAnsweredQuestions_TestAttempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "TestAttempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestAnsweredQuestions_TestQuestions_QuestionId",
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
                value: "816e0d13-debf-432a-9926-f83ae3053f02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "174f3131-2dcd-40a4-b0dd-d403b5af5f08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "4768d4ce-c0d1-443c-ad19-eda7d059798e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "2ab6b580-3958-40c5-a108-8b7c74fa0a43");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ce51442-f3a2-4be3-96e2-476a56a00f71", "AQAAAAEAACcQAAAAEPAryfj2xSmYUcJFHDD2cBv27ZrAxT0dG6163OZcree32pFJ29YcYp+/FQgvgeZFBQ==", "9bac28b0-bf4a-4cfb-8b79-7f9cd62570df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ecfe1f1-6bd7-4cb7-a776-acde439ec0a7", "AQAAAAEAACcQAAAAEJrrREOlOZSBKG5hi7RoWZ2yKrZn09x0fYBgi2a4F3zmbf/51MK/HvQeX7d2e4XufQ==", "09c91d9f-8fe0-4234-80e8-1fb65a862392" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f24b405-ac7f-41e6-9251-d0b370075237", "AQAAAAEAACcQAAAAEDOtbdJvIVCiYbfcBU0pgldayn434+LPFZ0PdtY2U/DEwwWb398aN3rkXgyDAX4Wwg==", "81ce1009-f6e0-40be-9d88-c7addb34999d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "272e456e-51bf-4c46-967e-0394c040c8cc", "AQAAAAEAACcQAAAAEMeRH4VMHaGDiOk5Nl6Smvqsz5/2rsEjhVQkTyvtJepxkS23b7aL8zurfo4ns0pj9Q==", "d18bcd04-5e41-46bc-b94e-43bee88e57c1" });

            migrationBuilder.CreateIndex(
                name: "IX_TestAnsweredQuestions_AnswerVariantId",
                table: "TestAnsweredQuestions",
                column: "AnswerVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnsweredQuestions_AttemptId",
                table: "TestAnsweredQuestions",
                column: "AttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnsweredQuestions_QuestionId",
                table: "TestAnsweredQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_TestId",
                table: "TestAttempts",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_UserId",
                table: "TestAttempts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestAnsweredQuestions");

            migrationBuilder.DropTable(
                name: "TestAttempts");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TestSchedules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeginTime",
                table: "TestSchedules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

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
        }
    }
}
