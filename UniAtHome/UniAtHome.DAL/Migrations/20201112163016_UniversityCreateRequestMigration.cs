using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class UniversityCreateRequestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversityCreateRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(nullable: false),
                    SubmitterFirstName = table.Column<string>(nullable: false),
                    SubmitterLastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: false),
                    Submitted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityCreateRequests", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "ce02f73b-7e5e-4bf8-b70a-f13afd494d86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "c92dcab9-cfd7-4055-9c3a-3432a53198c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "944b71b2-a316-411f-bbe3-e99171ab15c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "5dc11c9d-13ae-4332-a228-c3fb61ecb8a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50ac185a-ea76-458a-941b-49ffd20cebb1", "AQAAAAEAACcQAAAAEEFEPVW1yCuZQY4pYAi3rwTIWFroK255Kd8AX+kgnnXAg70JMet6DfVdszS+qS8tfA==", "1374e5fe-1910-4102-8408-c54479ade4ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f372340-d1b1-4d17-a1b0-0359641961bf", "AQAAAAEAACcQAAAAEMWifViQRyszyoave0rP8ASP7Iop5h9XvCDqIQv5o6rt0rG3WHOU5wTt86sd0jlQ7Q==", "de31b772-a574-4fe8-8258-d39c8c34d3e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37c8fa30-95af-4b37-b6b5-f27257547f7e", "AQAAAAEAACcQAAAAECDHlx4npTJVJzfCjGGoUHs6MpOad2hy0Hn9FQa8rdNx5ksh15J8zuBn+wHd88cAlQ==", "923928b1-a8b4-4b37-aa2a-eeebdacc263b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "921c6b13-cb7f-435a-9446-2493397e433e", "AQAAAAEAACcQAAAAEE0mDVXE48XvTHz9gtyM3eDG3TiOvrYc9rDG8iEWyK1crjGB+QFsGR4sWmh5jFta0A==", "3d4507db-dde5-40fd-a88d-4fa2132fbe30" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityCreateRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "0d10e3eb-effc-459d-8cf0-1ce241440b7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "e924d3b7-3038-4c98-86e3-333b607b26b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "0828444c-2201-4d35-ad2c-acb265aef893");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "1d365245-5602-4e02-8ce2-69dc39e06754");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8689661-8dd9-4cc5-9457-17823e6ca98c", "AQAAAAEAACcQAAAAELQPMNyQLkzXVVETu6NahgbdRVQREmSrTJ9zm7BORJW7XuyxXfFGgMuhtUq1z8x5BQ==", "9bd24f19-f61a-44fd-99fa-041ce5cc9848" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e78dac7-60e3-4d63-ac6b-a54b98f745f5", "AQAAAAEAACcQAAAAEK4l+0OxFLBLcEYVX+tAhJ62ITx5SEaoUWAP7+3rIzWY0xGBoq6YP59Gc4aDrorA2w==", "fc100cbb-6366-4d29-8d6e-b789866da465" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fccf489-0c8f-4216-849c-14e8996f9c5a", "AQAAAAEAACcQAAAAEE3+MIYLv7MNwJ3DpWtT/j/X6TTBLkjLjhY25E0YvrfvEVI0hJfn6TcQFvF1iqNzBg==", "ed3b4f25-16ed-4732-881c-cc5b24a1a603" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7766bb79-0960-4bcf-a452-2479e2a5f9f8", "AQAAAAEAACcQAAAAEDxjHFYTxbyrmWfXc1VGkOYevCYHy2UwgYX+nrLG+2QN5R5olV104s+tGF0hN9YesA==", "6ede6d02-02b2-44f1-a6d7-118318c43200" });
        }
    }
}
