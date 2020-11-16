using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAtHome.DAL.Migrations
{
    public partial class CountryToStringMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "UniversityCreateRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "a0b6419c-3653-4f58-98c7-a85c859e12ba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "bb2a12e6-ac16-4955-a80d-d10eb74f44cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "f341109e-eca8-48ad-82c5-b122413e429c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "598000fd-78c4-4108-86a9-ef197ce85879");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e756c2c3-5d76-4446-9a9b-b9a33fa1520b", "AQAAAAEAACcQAAAAEPUhYVrIZtO+/oIBJuzszWKYc0x0saJAlMIuFEk6+zBVj+WO33Zbk0GWFsIsDp1Piw==", "51178ab6-bd01-46bc-ba2e-0ebe4acd7f8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "526ac796-3452-4691-b436-f2de533a383b", "AQAAAAEAACcQAAAAELqjSPcIqxNutJec7O81smavdMOz0QehobXwA9SZLW4f+sxJ7bAyMwEGOidqKPn5vQ==", "ea57cf58-bc7b-4f7c-92ac-a93d98ef9c2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44a9a43b-083e-4a77-9f4d-309a4fd5d9ba", "AQAAAAEAACcQAAAAEKeqpJVRNeQ96v4JxJYo/xtl7+0/qTtOeNtkoV7Fl2/d2ljobcKtVxE/tuF6YJ5I2Q==", "2f90ea2b-42af-4470-9c0d-e62d9b8b792a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e8ad5cb-cb0f-48bb-a940-77031dec4bc5", "AQAAAAEAACcQAAAAEEllom4tBAESRyu30P+mNUzE4v6w+2zAwH5CEkOCkhy+AM7Ui+baaafEux6tX/i1rg==", "006eb7e6-ee3d-4018-998b-bb6f6435a1ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Country",
                table: "UniversityCreateRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

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
        }
    }
}
