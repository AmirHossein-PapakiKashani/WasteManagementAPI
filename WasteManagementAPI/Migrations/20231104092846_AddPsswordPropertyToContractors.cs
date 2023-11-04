using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPsswordPropertyToContractors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Contractors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Contractors");
        }
    }
}
