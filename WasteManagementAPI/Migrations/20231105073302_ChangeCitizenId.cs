using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCitizenId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CitizensId",
                table: "Citizens",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Citizens",
                newName: "CitizensId");
        }
    }
}
