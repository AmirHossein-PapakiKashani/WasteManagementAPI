using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRoleUserNameToUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupervisorUserName",
                table: "Supervisor",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "MunicipalitiesUserName",
                table: "Municipality",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "ContractorsUserName",
                table: "Contractors",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "EmployeeUserName",
                table: "CollectionBooths",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "CitizensUserName",
                table: "Citizens",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Supervisor",
                newName: "SupervisorUserName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Municipality",
                newName: "MunicipalitiesUserName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Contractors",
                newName: "ContractorsUserName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "CollectionBooths",
                newName: "EmployeeUserName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Citizens",
                newName: "CitizensUserName");
        }
    }
}
