using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNamePropertyToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Citizens",
                newName: "CitizensUserName");

            migrationBuilder.AddColumn<string>(
                name: "SupervisorUserName",
                table: "Supervisor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MunicipalitiesUserName",
                table: "Municipality",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Contractors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ContractorsUserName",
                table: "Contractors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupervisorUserName",
                table: "Supervisor");

            migrationBuilder.DropColumn(
                name: "MunicipalitiesUserName",
                table: "Municipality");

            migrationBuilder.DropColumn(
                name: "ContractorsUserName",
                table: "Contractors");

            migrationBuilder.RenameColumn(
                name: "CitizensUserName",
                table: "Citizens",
                newName: "UserName");

            migrationBuilder.AlterColumn<int>(
                name: "Password",
                table: "Contractors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
