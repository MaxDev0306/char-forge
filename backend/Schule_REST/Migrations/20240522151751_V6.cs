using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schule_REST.Migrations
{
    /// <inheritdoc />
    public partial class V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProficiencyBonus",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SubClassId",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "ProficiencyBonus",
                table: "ClassSpecificFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProficiencyBonus",
                table: "ClassSpecificFeatures");

            migrationBuilder.AddColumn<int>(
                name: "ProficiencyBonus",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubClassId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
