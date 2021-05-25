using Microsoft.EntityFrameworkCore.Migrations;

namespace ExcellenceServer.Migrations
{
    public partial class initialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessPartners",
                table: "BusinessPartners");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityCard",
                table: "BusinessPartners",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessPartners",
                table: "BusinessPartners",
                column: "IdentityCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessPartners",
                table: "BusinessPartners");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityCard",
                table: "BusinessPartners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessPartners",
                table: "BusinessPartners",
                column: "PartnerId");
        }
    }
}
