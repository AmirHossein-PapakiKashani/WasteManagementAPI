using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class DropAllOfRolesExeptCitizen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Citizens_CitizensId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_CollectionBooths_CollectionBoothsId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "CollectionBooths");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Supervisor");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_CitizensId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_CollectionBoothsId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "CitizensId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "CollectionBoothsId",
                table: "Shipments");

            migrationBuilder.AddColumn<int>(
                name: "ShipmentsId",
                table: "Citizens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_ShipmentsId",
                table: "Citizens",
                column: "ShipmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citizens_Shipments_ShipmentsId",
                table: "Citizens",
                column: "ShipmentsId",
                principalTable: "Shipments",
                principalColumn: "ShipmentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citizens_Shipments_ShipmentsId",
                table: "Citizens");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_ShipmentsId",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "ShipmentsId",
                table: "Citizens");

            migrationBuilder.AddColumn<int>(
                name: "CitizensId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CollectionBoothsId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CollectionBooths",
                columns: table => new
                {
                    CollectionBoothsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeePasswored = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionBooths", x => x.CollectionBoothsId);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    MunicipalitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.MunicipalitiesId);
                });

            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    ContractorsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalitiesId = table.Column<int>(type: "int", nullable: false),
                    Nmae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.ContractorsId);
                    table.ForeignKey(
                        name: "FK_Contractors_Municipality_MunicipalitiesId",
                        column: x => x.MunicipalitiesId,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalitiesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supervisor",
                columns: table => new
                {
                    SupervisorsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalitiesId = table.Column<int>(type: "int", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisor", x => x.SupervisorsId);
                    table.ForeignKey(
                        name: "FK_Supervisor_Municipality_MunicipalitiesId",
                        column: x => x.MunicipalitiesId,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalitiesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CitizensId",
                table: "Shipments",
                column: "CitizensId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CollectionBoothsId",
                table: "Shipments",
                column: "CollectionBoothsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_MunicipalitiesId",
                table: "Contractors",
                column: "MunicipalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_MunicipalitiesId",
                table: "Supervisor",
                column: "MunicipalitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Citizens_CitizensId",
                table: "Shipments",
                column: "CitizensId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_CollectionBooths_CollectionBoothsId",
                table: "Shipments",
                column: "CollectionBoothsId",
                principalTable: "CollectionBooths",
                principalColumn: "CollectionBoothsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
