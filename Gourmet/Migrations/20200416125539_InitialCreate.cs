using Microsoft.EntityFrameworkCore.Migrations;

namespace Gourmet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    AlimentoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Calorias = table.Column<int>(nullable: false),
                    GrupoAlim = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.AlimentoId);
                });

            migrationBuilder.CreateTable(
                name: "Comidas",
                columns: table => new
                {
                    ComidaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comidas", x => x.ComidaId);
                });

            migrationBuilder.CreateTable(
                name: "Recetarios",
                columns: table => new
                {
                    RecetarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetarios", x => x.RecetarioId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlimentoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    UnidadDeMedida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IngredienteId);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Alimentos_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimentos",
                        principalColumn: "AlimentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecetarioComidas",
                columns: table => new
                {
                    RecetarioId = table.Column<int>(nullable: false),
                    ComidaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetarioComidas", x => new { x.RecetarioId, x.ComidaId });
                    table.ForeignKey(
                        name: "FK_RecetarioComidas_Comidas_ComidaId",
                        column: x => x.ComidaId,
                        principalTable: "Comidas",
                        principalColumn: "ComidaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetarioComidas_Recetarios_RecetarioId",
                        column: x => x.RecetarioId,
                        principalTable: "Recetarios",
                        principalColumn: "RecetarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComidaIngredientes",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(nullable: false),
                    ComidaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComidaIngredientes", x => new { x.ComidaId, x.IngredienteId });
                    table.ForeignKey(
                        name: "FK_ComidaIngredientes_Comidas_ComidaId",
                        column: x => x.ComidaId,
                        principalTable: "Comidas",
                        principalColumn: "ComidaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComidaIngredientes_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "IngredienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComidaIngredientes_IngredienteId",
                table: "ComidaIngredientes",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_AlimentoId",
                table: "Ingredientes",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetarioComidas_ComidaId",
                table: "RecetarioComidas",
                column: "ComidaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComidaIngredientes");

            migrationBuilder.DropTable(
                name: "RecetarioComidas");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Comidas");

            migrationBuilder.DropTable(
                name: "Recetarios");

            migrationBuilder.DropTable(
                name: "Alimentos");
        }
    }
}
