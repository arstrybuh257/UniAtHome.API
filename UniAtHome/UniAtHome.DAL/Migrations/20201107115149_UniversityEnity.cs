using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class UniversityEnity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversityAdmins",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UniversityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityAdmins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UniversityAdmins_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniversityAdmins_AspNetUsers_UserId",
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
                value: "e55eae60-566c-48bb-9560-3f03b3e92bef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "ec149073-3a41-466d-954d-b408f207cbb3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "511cfeed-782b-4853-9b21-77f146439f90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "557c7067-29bf-4592-8a80-fc235b869b8b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f233a01-97b0-452b-b116-32a34791afb9", "AQAAAAEAACcQAAAAEMHsTs19LAgVrClzEulQC0roRkO6MHgWd4h0Miufoowqraz6lFm/Fwz+JLemRTl/EQ==", "8d1b5e3a-5f7a-4f5a-9925-ff8fd299b693" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f290e91-eea4-4f0c-af67-17c4f74ea864", "AQAAAAEAACcQAAAAECZsBE4BiXjLDQw8qkua5qgDYsEueXqvAvxfB7V57e8erSPG9GpR7b5UQWPgD928tQ==", "3450a5db-5e6d-4412-b48c-3923d04db0b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcb75f82-0ba8-4a4e-ade7-02281ea4252f", "AQAAAAEAACcQAAAAENh1buA6ln4w1/k7KmMn8QmeDmEVJxb3snYfbl/bU8pTPKCE6RtKIY9iy2Fpuzwg3Q==", "ad4e9c25-7088-4dcc-b325-e77db2961322" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", 0, "a6b372d1-e80a-41c0-ba3e-7b863d5e64f1", "uadmin@gmail.com", false, "Vladimir", "Bream", false, null, "uadmin@gmail.com", "uadmin@gmail.com", "AQAAAAEAACcQAAAAEMMrnTGw32ltF0DRbAYfIY6riOQxXpXqXxQaWCm6bT11VCzU1q5gLBsfrfP/gvc2Ww==", null, false, "608e3338-609a-42e3-8454-1c6a363fd8a3", false, "uadmin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "NURE" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", "99DA7670-5471-414F-834E-9B3A6B6C8F6F" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "UserId",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                column: "UniversityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "UserId",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                column: "UniversityId",
                value: 1);

            migrationBuilder.InsertData(
                table: "UniversityAdmins",
                columns: new[] { "UserId", "UniversityId" },
                values: new object[] { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UniversityId",
                table: "Teachers",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityId",
                table: "Students",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UniversityId",
                table: "Courses",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityAdmins_UniversityId",
                table: "UniversityAdmins",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Universities_UniversityId",
                table: "Courses",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Universities_UniversityId",
                table: "Students",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Universities_UniversityId",
                table: "Teachers",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Universities_UniversityId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Universities_UniversityId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Universities_UniversityId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "UniversityAdmins");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UniversityId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_UniversityId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UniversityId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", "99DA7670-5471-414F-834E-9B3A6B6C8F6F" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "073349fe-b71c-4a80-9c50-3c7ebc4f4499");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "8313e7ff-3ca6-4044-8a01-336809498e05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "5b9eb6e3-7d7e-4335-9832-bfb8622d56f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "742ecdb3-37c1-4eea-8961-96f49c390dc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12aa89a7-dd28-463b-b30a-b688d3c82197", "AQAAAAEAACcQAAAAEAMqjLn7YxgNTNbA5tpNEyTJcH6eXYpxCaSHYeqJNRpEmUBNHrON3Lc7QxBp8FLj6Q==", "749be264-803e-48b0-bc4c-34b55676b2dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b232a11-01ab-40a9-9e33-0ef7dbc6fbd1", "AQAAAAEAACcQAAAAELcE7h7wRU2wAuwB6nzKfUu1mODxuNlaK2/3KDwbgtQEibEvPPKcvgADSAsdRiylEQ==", "b2365c85-bb28-49ec-ba20-c2ec851b1951" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "256e1fed-6e83-4883-b18e-31ac054befd7", "AQAAAAEAACcQAAAAEBwTshmKVFSA59SBgEm9PKGkI/vgB3ZoEZPs3YZx/SsIB0T//z/Bxf/tPkPD2KY0tQ==", "ba21e6ad-12d7-4a33-be72-b4bcc4e099a2" });
        }
    }
}
