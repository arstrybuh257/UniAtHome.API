using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class FixTypoInTestAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAnsweredQuestions_TestAttempts_AttemptId",
                table: "TestAnsweredQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAnsweredQuestions",
                table: "TestAnsweredQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestAnsweredQuestions_AttemptId",
                table: "TestAnsweredQuestions");

            migrationBuilder.DropColumn(
                name: "AttempId",
                table: "TestAnsweredQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "AttemptId",
                table: "TestAnsweredQuestions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAnsweredQuestions",
                table: "TestAnsweredQuestions",
                columns: new[] { "AttemptId", "QuestionId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "46c41b0e-44f7-44f2-8289-829aec249d12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "11990033-8446-4df3-91cf-b14435a7212f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "f838dd86-18d7-4b85-92bc-f62a3c742218");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "e3d72959-756d-4d71-b20a-ed5c26a56f22");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42c312ee-cd5e-46ee-93a2-2b10b27ee0cf", "AQAAAAEAACcQAAAAEO0AqZ0wWKYxr3lwFOx1KYBrkGyq5eGajw2I/HlEiOCvaRe7WzPd+eX7GJaEJob/fA==", "10653996-7d96-46a2-98cf-24847766aee7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a9ed5f3-406f-44ac-b600-253cc515895e", "AQAAAAEAACcQAAAAEFNAVeeTEeraVmSuRZa33JC2P+1b0+FzlbutopsQsaaxkGpCx5+R07BXpEGeIkILAg==", "eec56078-e5e4-49ff-8a3a-9585bb9612c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d753f9de-7e6e-4a18-9e0f-bb49a3f79bca", "AQAAAAEAACcQAAAAEG41jVVc8bbW7dERIZiyFY7vh8xH+UTKO6Zqs3u4spTlDZx5eTtZllDRVY4CMVl4Cg==", "dbd16839-dadf-46ca-a4dc-372713cafd89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "196a8854-3947-4d30-91ff-7dcf7f235d87", "AQAAAAEAACcQAAAAEFtJBgL13oFx0NMa2ut2fOdEucF7b+RL7CAUMqw1R8TiFywJEuv3Pwng7c+zGEU1uA==", "efb2dbc6-575c-471d-a36e-fbc9b8f4f45b" });

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnsweredQuestions_TestAttempts_AttemptId",
                table: "TestAnsweredQuestions",
                column: "AttemptId",
                principalTable: "TestAttempts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAnsweredQuestions_TestAttempts_AttemptId",
                table: "TestAnsweredQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAnsweredQuestions",
                table: "TestAnsweredQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "AttemptId",
                table: "TestAnsweredQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AttempId",
                table: "TestAnsweredQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAnsweredQuestions",
                table: "TestAnsweredQuestions",
                columns: new[] { "AttempId", "QuestionId" });

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
                name: "IX_TestAnsweredQuestions_AttemptId",
                table: "TestAnsweredQuestions",
                column: "AttemptId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnsweredQuestions_TestAttempts_AttemptId",
                table: "TestAnsweredQuestions",
                column: "AttemptId",
                principalTable: "TestAttempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
