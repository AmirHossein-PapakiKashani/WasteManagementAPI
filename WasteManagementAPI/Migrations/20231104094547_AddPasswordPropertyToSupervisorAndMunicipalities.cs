using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordPropertyToSupervisorAndMunicipalities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Supervisor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Municipality",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Supervisor");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Municipality");
        }
    }
}
