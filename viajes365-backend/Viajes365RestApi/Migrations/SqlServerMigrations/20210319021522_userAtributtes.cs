using Microsoft.EntityFrameworkCore.Migrations;

namespace Viajes365RestApi.Migrations.SqlServerMigrations
{
    public partial class userAtributtes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirm",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TermsAndConditionsChecked",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirm",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TermsAndConditionsChecked",
                table: "Users");
        }
    }
}
