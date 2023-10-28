using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProductScorePropertyToMainProductClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ProductScore",
                table: "MainProducts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "MainProducts",
                keyColumn: "MainProductId",
                keyValue: 1,
                column: "ProductScore",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "MainProducts",
                keyColumn: "MainProductId",
                keyValue: 2,
                column: "ProductScore",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "MainProducts",
                keyColumn: "MainProductId",
                keyValue: 3,
                column: "ProductScore",
                value: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductScore",
                table: "MainProducts");
        }
    }
}
