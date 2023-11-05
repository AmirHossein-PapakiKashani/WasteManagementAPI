using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeleteWasteTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WasteTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WasteTypes",
                columns: table => new
                {
                    WasteTypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentsId = table.Column<int>(type: "int", nullable: false),
                    ShipmentId = table.Column<int>(type: "int", nullable: false),
                    WasteName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteTypes", x => x.WasteTypesId);
                    table.ForeignKey(
                        name: "FK_WasteTypes_Shipments_ShipmentsId",
                        column: x => x.ShipmentsId,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WasteTypes_ShipmentsId",
                table: "WasteTypes",
                column: "ShipmentsId");
        }
    }
}
