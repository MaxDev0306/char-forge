using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schule_REST.Migrations
{
    /// <inheritdoc />
    public partial class V8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassProficiency",
                columns: table => new
                {
                    ClasssId = table.Column<int>(type: "int", nullable: false),
                    ProficienciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassProficiency", x => new { x.ClasssId, x.ProficienciesId });
                    table.ForeignKey(
                        name: "FK_ClassProficiency_Classes_ClasssId",
                        column: x => x.ClasssId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassProficiency_Proficiencies_ProficienciesId",
                        column: x => x.ProficienciesId,
                        principalTable: "Proficiencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClassProficiency_ProficienciesId",
                table: "ClassProficiency",
                column: "ProficienciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassProficiency");
        }
    }
}
