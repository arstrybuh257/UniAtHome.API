using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class GroupNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Group",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Group");

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
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6b372d1-e80a-41c0-ba3e-7b863d5e64f1", "AQAAAAEAACcQAAAAEMMrnTGw32ltF0DRbAYfIY6riOQxXpXqXxQaWCm6bT11VCzU1q5gLBsfrfP/gvc2Ww==", "608e3338-609a-42e3-8454-1c6a363fd8a3" });

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
        }
    }
}
