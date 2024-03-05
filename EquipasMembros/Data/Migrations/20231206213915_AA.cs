using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipasMembros.Data.Migrations
{
    /// <inheritdoc />
    public partial class AA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tequipas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEquipa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tequipas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tmembros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMembro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tmembros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tmembros_Tequipas_EquipaId",
                        column: x => x.EquipaId,
                        principalTable: "Tequipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tmembros_EquipaId",
                table: "Tmembros",
                column: "EquipaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tmembros");

            migrationBuilder.DropTable(
                name: "Tequipas");
        }
    }
}
