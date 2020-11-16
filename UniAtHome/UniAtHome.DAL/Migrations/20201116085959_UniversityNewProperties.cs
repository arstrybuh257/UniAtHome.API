using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class UniversityNewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Submitted",
                table: "UniversityCreateRequests");

            migrationBuilder.AlterColumn<string>(
                name: "UniversityShortName",
                table: "UniversityCreateRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UniversityCreateRequests",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Universities",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Universities",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Universities",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Universities",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "f6c2a773-2934-4150-91c8-a301a1621281");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "35991cc3-6e6a-46bf-8dc6-38c1590156c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "69469582-2665-4d08-840b-6537ab759c1b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "94fcd6d4-2b6a-4a61-9941-6a2f1ef4048d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e198ebaf-bcdc-4bee-b5be-0ce918afe5d9", "AQAAAAEAACcQAAAAEA3wff2v/9lZPZlhYWsTrVwZmAkY9sOcUf2py3+BIitjQWdFcZ4Kx0k6lxrr4OWilA==", "36c04936-ee5c-41b9-b77c-23f2a3307f34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2143b4f4-780d-403d-b573-5bd15cb28152", "AQAAAAEAACcQAAAAEKsE6PFnsEg6qCvwXQra3A5HtGTtV7jJTuO+SwmP1SyrfsWVnmLdQgwZQWCPw7k3FQ==", "259d4bde-e4ca-41f4-a6d4-21b191eed954" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c917c17c-497e-4fb8-85c6-631e494a3ba9", "AQAAAAEAACcQAAAAEPkClNQsN3N5d4F8nZCOPHGZYQn2UAbaFwOIdPORA2/pARRRMHMPC3NYpXATXRUitw==", "eba82754-6495-4412-9668-86dbe16135e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03651c09-21fd-4cda-b3c8-8b022414a20a", "AQAAAAEAACcQAAAAEHtHpFPBfGjMvmkZ10GdY7IODltjvqM4U6f3KqmNGQScJYPdGMZvXrVpeQ4cZMTdYQ==", "80c4b694-3664-45b1-8e85-c21990ada1ba" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Country", "Name", "ShortName" },
                values: new object[] { "Nauky Ave. 14, Kharkiv", "Ukraine", "Kharkiv National University of Radio Electronics", "Nure" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UniversityShortName",
                table: "UniversityCreateRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UniversityCreateRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Submitted",
                table: "UniversityCreateRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Universities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Country",
                table: "Universities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "64fd29d3-3977-40ab-8886-0039602ae4c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "18b6dc31-d080-4c5d-9c48-095599da41c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "33852270-ea17-4e3a-93b4-d46e45e7904d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "14e94dcd-cff4-47e6-8a95-67b26a297fe6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6187bb0-e279-4cf2-8197-36125b49737f", "AQAAAAEAACcQAAAAEDTZxhqgGQXAiXUoyhMkXQPjqikxqSIk7zVgpLuP9/LEyAG+KkWUWL6R0W+xr63ytQ==", "ff1f2d7e-204d-4382-946c-ad1330512db7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5947a091-c231-4847-9210-d14779286cad", "AQAAAAEAACcQAAAAEHIdXXVCInIQFmbwX+nLrraH8HiqOY5QhAwhF+Lm7UFUYP5C7ssYR6tyvyGSpqb+cA==", "519d436f-86f9-471f-b8e6-f40d4750ff9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "974fe6ad-b196-4268-ad4f-72ae4b742862", "AQAAAAEAACcQAAAAEFaw5YcblznYga/eY/on9jLNg7eYKXdAF+OgjdCeloGH2ERSPi6Sw1btX7gDwo6f2g==", "65993716-1fde-450a-9c5c-d6ca0d05cf08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54ff0695-37cc-4658-aef7-c1946f8b240e", "AQAAAAEAACcQAAAAEMZjCAyG878vVWhiuArft3gNhGm2Ypw/UoL1IA+fbU3M27YQ1AMYdfjRCKUXqAE/EQ==", "554edb41-76a1-44bd-af87-f050295be934" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Country", "Name", "ShortName" },
                values: new object[] { null, 0, "NURE", null });
        }
    }
}
