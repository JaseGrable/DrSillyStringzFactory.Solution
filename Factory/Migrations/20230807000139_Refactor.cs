using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MachineDescription",
                table: "Machines",
                newName: "ManufactureDate");

            migrationBuilder.RenameColumn(
                name: "EngineerDetails",
                table: "Engineers",
                newName: "JobTitle");

            migrationBuilder.AddColumn<int>(
                name: "EngineerId",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "Engineers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineerId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Engineers");

            migrationBuilder.RenameColumn(
                name: "ManufactureDate",
                table: "Machines",
                newName: "MachineDescription");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Engineers",
                newName: "EngineerDetails");
        }
    }
}
