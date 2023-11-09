using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shipments_CitizensId",
                table: "Shipments");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CitizensId",
                table: "Shipments",
                column: "CitizensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shipments_CitizensId",
                table: "Shipments");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CitizensId",
                table: "Shipments",
                column: "CitizensId",
                unique: true);
        }
    }
}
