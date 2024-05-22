using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schule_REST.Migrations
{
    /// <inheritdoc />
    public partial class V7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProficiencyBonus",
                table: "ClassSpecificFeatures");

            migrationBuilder.RenameColumn(
                name: "SwimingSpeed",
                table: "Races",
                newName: "SwimmingSpeed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SwimmingSpeed",
                table: "Races",
                newName: "SwimingSpeed");

            migrationBuilder.AddColumn<int>(
                name: "ProficiencyBonus",
                table: "ClassSpecificFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
